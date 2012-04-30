#!/usr/bin/perl -w

use strict;
use File::Basename;
use Cwd 'abs_path';

die "Usage: $0 project-dir target [output-name]" unless $#ARGV == 1 || $#ARGV == 2;

my ($project_dir,$target,$name) = @ARGV;

my $solution_dir = dirname(abs_path($0));
die "Not a directory: $solution_dir" unless -d $solution_dir;
die "Not a directory: $project_dir" unless -d $project_dir;
die "Invalid target" unless $target =~ /^\w+$/;
die "Invalid name" unless $#ARGV == 1 || $name =~ /^\w+$/;

$project_dir = abs_path($project_dir);

if ($#ARGV == 1) {
    my $part = basename($project_dir);
    die "Must specify name" unless $part =~ /^\w+$/;
    $name = $part . "-res.zip";
}

my $framework_apk = $solution_dir . "/android/system-root/framework/framework-res.apk";
die "Invalid solution dir" unless -f $framework_apk;

my $target_dir = "$solution_dir/build/$target";
die "Invalid target" unless -d $target_dir && -f "$target_dir/xorpt";

my $manifest = "$project_dir/AndroidManifest.xml";
die "No 'AndroidManifest.xml' in $project_dir" unless -f $manifest;
die "No 'res' directory in $project_dir" unless -d "$project_dir/res";

my $reszip = "$project_dir/$name";
my $xorpt = "$target_dir/xorpt";

my @args = ($xorpt, "p", "-f", "-S", "$project_dir/res", "-F", $reszip, "-J", $project_dir, "-M", $manifest, "-I", $framework_apk);
system(@args) == 0 or die "Running xorpt failed!";

printf "Successfully created $reszip.\n";
