/*
 * Copyright (C) 2007 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package dalvik.bytecode;

/**
 * A list of all normal (not implementation-specific) Dalvik opcodes.
 */
public interface Opcodes {
    /*
     * IMPORTANT NOTE: The contents of this file are mostly generated
     * automatically by the opcode-gen tool. Any edits to the generated
     * sections will get wiped out the next time the tool is run.
     */

    // BEGIN(libcore-opcodes); GENERATED AUTOMATICALLY BY opcode-gen
    int OP_NOP                          = 0x0000;
    int OP_MOVE                         = 0x0001;
    int OP_MOVE_FROM16                  = 0x0002;
    int OP_MOVE_16                      = 0x0003;
    int OP_MOVE_WIDE                    = 0x0004;
    int OP_MOVE_WIDE_FROM16             = 0x0005;
    int OP_MOVE_WIDE_16                 = 0x0006;
    int OP_MOVE_OBJECT                  = 0x0007;
    int OP_MOVE_OBJECT_FROM16           = 0x0008;
    int OP_MOVE_OBJECT_16               = 0x0009;
    int OP_MOVE_RESULT                  = 0x000a;
    int OP_MOVE_RESULT_WIDE             = 0x000b;
    int OP_MOVE_RESULT_OBJECT           = 0x000c;
    int OP_MOVE_EXCEPTION               = 0x000d;
    int OP_RETURN_VOID                  = 0x000e;
    int OP_RETURN                       = 0x000f;
    int OP_RETURN_WIDE                  = 0x0010;
    int OP_RETURN_OBJECT                = 0x0011;
    int OP_CONST_4                      = 0x0012;
    int OP_CONST_16                     = 0x0013;
    int OP_CONST                        = 0x0014;
    int OP_CONST_HIGH16                 = 0x0015;
    int OP_CONST_WIDE_16                = 0x0016;
    int OP_CONST_WIDE_32                = 0x0017;
    int OP_CONST_WIDE                   = 0x0018;
    int OP_CONST_WIDE_HIGH16            = 0x0019;
    int OP_CONST_STRING                 = 0x001a;
    int OP_CONST_STRING_JUMBO           = 0x001b;
    int OP_CONST_CLASS                  = 0x001c;
    int OP_MONITOR_ENTER                = 0x001d;
    int OP_MONITOR_EXIT                 = 0x001e;
    int OP_CHECK_CAST                   = 0x001f;
    int OP_INSTANCE_OF                  = 0x0020;
    int OP_ARRAY_LENGTH                 = 0x0021;
    int OP_NEW_INSTANCE                 = 0x0022;
    int OP_NEW_ARRAY                    = 0x0023;
    int OP_FILLED_NEW_ARRAY             = 0x0024;
    int OP_FILLED_NEW_ARRAY_RANGE       = 0x0025;
    int OP_FILL_ARRAY_DATA              = 0x0026;
    int OP_THROW                        = 0x0027;
    int OP_GOTO                         = 0x0028;
    int OP_GOTO_16                      = 0x0029;
    int OP_GOTO_32                      = 0x002a;
    int OP_PACKED_SWITCH                = 0x002b;
    int OP_SPARSE_SWITCH                = 0x002c;
    int OP_CMPL_FLOAT                   = 0x002d;
    int OP_CMPG_FLOAT                   = 0x002e;
    int OP_CMPL_DOUBLE                  = 0x002f;
    int OP_CMPG_DOUBLE                  = 0x0030;
    int OP_CMP_LONG                     = 0x0031;
    int OP_IF_EQ                        = 0x0032;
    int OP_IF_NE                        = 0x0033;
    int OP_IF_LT                        = 0x0034;
    int OP_IF_GE                        = 0x0035;
    int OP_IF_GT                        = 0x0036;
    int OP_IF_LE                        = 0x0037;
    int OP_IF_EQZ                       = 0x0038;
    int OP_IF_NEZ                       = 0x0039;
    int OP_IF_LTZ                       = 0x003a;
    int OP_IF_GEZ                       = 0x003b;
    int OP_IF_GTZ                       = 0x003c;
    int OP_IF_LEZ                       = 0x003d;
    int OP_AGET                         = 0x0044;
    int OP_AGET_WIDE                    = 0x0045;
    int OP_AGET_OBJECT                  = 0x0046;
    int OP_AGET_BOOLEAN                 = 0x0047;
    int OP_AGET_BYTE                    = 0x0048;
    int OP_AGET_CHAR                    = 0x0049;
    int OP_AGET_SHORT                   = 0x004a;
    int OP_APUT                         = 0x004b;
    int OP_APUT_WIDE                    = 0x004c;
    int OP_APUT_OBJECT                  = 0x004d;
    int OP_APUT_BOOLEAN                 = 0x004e;
    int OP_APUT_BYTE                    = 0x004f;
    int OP_APUT_CHAR                    = 0x0050;
    int OP_APUT_SHORT                   = 0x0051;
    int OP_IGET                         = 0x0052;
    int OP_IGET_WIDE                    = 0x0053;
    int OP_IGET_OBJECT                  = 0x0054;
    int OP_IGET_BOOLEAN                 = 0x0055;
    int OP_IGET_BYTE                    = 0x0056;
    int OP_IGET_CHAR                    = 0x0057;
    int OP_IGET_SHORT                   = 0x0058;
    int OP_IPUT                         = 0x0059;
    int OP_IPUT_WIDE                    = 0x005a;
    int OP_IPUT_OBJECT                  = 0x005b;
    int OP_IPUT_BOOLEAN                 = 0x005c;
    int OP_IPUT_BYTE                    = 0x005d;
    int OP_IPUT_CHAR                    = 0x005e;
    int OP_IPUT_SHORT                   = 0x005f;
    int OP_SGET                         = 0x0060;
    int OP_SGET_WIDE                    = 0x0061;
    int OP_SGET_OBJECT                  = 0x0062;
    int OP_SGET_BOOLEAN                 = 0x0063;
    int OP_SGET_BYTE                    = 0x0064;
    int OP_SGET_CHAR                    = 0x0065;
    int OP_SGET_SHORT                   = 0x0066;
    int OP_SPUT                         = 0x0067;
    int OP_SPUT_WIDE                    = 0x0068;
    int OP_SPUT_OBJECT                  = 0x0069;
    int OP_SPUT_BOOLEAN                 = 0x006a;
    int OP_SPUT_BYTE                    = 0x006b;
    int OP_SPUT_CHAR                    = 0x006c;
    int OP_SPUT_SHORT                   = 0x006d;
    int OP_INVOKE_VIRTUAL               = 0x006e;
    int OP_INVOKE_SUPER                 = 0x006f;
    int OP_INVOKE_DIRECT                = 0x0070;
    int OP_INVOKE_STATIC                = 0x0071;
    int OP_INVOKE_INTERFACE             = 0x0072;
    int OP_INVOKE_VIRTUAL_RANGE         = 0x0074;
    int OP_INVOKE_SUPER_RANGE           = 0x0075;
    int OP_INVOKE_DIRECT_RANGE          = 0x0076;
    int OP_INVOKE_STATIC_RANGE          = 0x0077;
    int OP_INVOKE_INTERFACE_RANGE       = 0x0078;
    int OP_NEG_INT                      = 0x007b;
    int OP_NOT_INT                      = 0x007c;
    int OP_NEG_LONG                     = 0x007d;
    int OP_NOT_LONG                     = 0x007e;
    int OP_NEG_FLOAT                    = 0x007f;
    int OP_NEG_DOUBLE                   = 0x0080;
    int OP_INT_TO_LONG                  = 0x0081;
    int OP_INT_TO_FLOAT                 = 0x0082;
    int OP_INT_TO_DOUBLE                = 0x0083;
    int OP_LONG_TO_INT                  = 0x0084;
    int OP_LONG_TO_FLOAT                = 0x0085;
    int OP_LONG_TO_DOUBLE               = 0x0086;
    int OP_FLOAT_TO_INT                 = 0x0087;
    int OP_FLOAT_TO_LONG                = 0x0088;
    int OP_FLOAT_TO_DOUBLE              = 0x0089;
    int OP_DOUBLE_TO_INT                = 0x008a;
    int OP_DOUBLE_TO_LONG               = 0x008b;
    int OP_DOUBLE_TO_FLOAT              = 0x008c;
    int OP_INT_TO_BYTE                  = 0x008d;
    int OP_INT_TO_CHAR                  = 0x008e;
    int OP_INT_TO_SHORT                 = 0x008f;
    int OP_ADD_INT                      = 0x0090;
    int OP_SUB_INT                      = 0x0091;
    int OP_MUL_INT                      = 0x0092;
    int OP_DIV_INT                      = 0x0093;
    int OP_REM_INT                      = 0x0094;
    int OP_AND_INT                      = 0x0095;
    int OP_OR_INT                       = 0x0096;
    int OP_XOR_INT                      = 0x0097;
    int OP_SHL_INT                      = 0x0098;
    int OP_SHR_INT                      = 0x0099;
    int OP_USHR_INT                     = 0x009a;
    int OP_ADD_LONG                     = 0x009b;
    int OP_SUB_LONG                     = 0x009c;
    int OP_MUL_LONG                     = 0x009d;
    int OP_DIV_LONG                     = 0x009e;
    int OP_REM_LONG                     = 0x009f;
    int OP_AND_LONG                     = 0x00a0;
    int OP_OR_LONG                      = 0x00a1;
    int OP_XOR_LONG                     = 0x00a2;
    int OP_SHL_LONG                     = 0x00a3;
    int OP_SHR_LONG                     = 0x00a4;
    int OP_USHR_LONG                    = 0x00a5;
    int OP_ADD_FLOAT                    = 0x00a6;
    int OP_SUB_FLOAT                    = 0x00a7;
    int OP_MUL_FLOAT                    = 0x00a8;
    int OP_DIV_FLOAT                    = 0x00a9;
    int OP_REM_FLOAT                    = 0x00aa;
    int OP_ADD_DOUBLE                   = 0x00ab;
    int OP_SUB_DOUBLE                   = 0x00ac;
    int OP_MUL_DOUBLE                   = 0x00ad;
    int OP_DIV_DOUBLE                   = 0x00ae;
    int OP_REM_DOUBLE                   = 0x00af;
    int OP_ADD_INT_2ADDR                = 0x00b0;
    int OP_SUB_INT_2ADDR                = 0x00b1;
    int OP_MUL_INT_2ADDR                = 0x00b2;
    int OP_DIV_INT_2ADDR                = 0x00b3;
    int OP_REM_INT_2ADDR                = 0x00b4;
    int OP_AND_INT_2ADDR                = 0x00b5;
    int OP_OR_INT_2ADDR                 = 0x00b6;
    int OP_XOR_INT_2ADDR                = 0x00b7;
    int OP_SHL_INT_2ADDR                = 0x00b8;
    int OP_SHR_INT_2ADDR                = 0x00b9;
    int OP_USHR_INT_2ADDR               = 0x00ba;
    int OP_ADD_LONG_2ADDR               = 0x00bb;
    int OP_SUB_LONG_2ADDR               = 0x00bc;
    int OP_MUL_LONG_2ADDR               = 0x00bd;
    int OP_DIV_LONG_2ADDR               = 0x00be;
    int OP_REM_LONG_2ADDR               = 0x00bf;
    int OP_AND_LONG_2ADDR               = 0x00c0;
    int OP_OR_LONG_2ADDR                = 0x00c1;
    int OP_XOR_LONG_2ADDR               = 0x00c2;
    int OP_SHL_LONG_2ADDR               = 0x00c3;
    int OP_SHR_LONG_2ADDR               = 0x00c4;
    int OP_USHR_LONG_2ADDR              = 0x00c5;
    int OP_ADD_FLOAT_2ADDR              = 0x00c6;
    int OP_SUB_FLOAT_2ADDR              = 0x00c7;
    int OP_MUL_FLOAT_2ADDR              = 0x00c8;
    int OP_DIV_FLOAT_2ADDR              = 0x00c9;
    int OP_REM_FLOAT_2ADDR              = 0x00ca;
    int OP_ADD_DOUBLE_2ADDR             = 0x00cb;
    int OP_SUB_DOUBLE_2ADDR             = 0x00cc;
    int OP_MUL_DOUBLE_2ADDR             = 0x00cd;
    int OP_DIV_DOUBLE_2ADDR             = 0x00ce;
    int OP_REM_DOUBLE_2ADDR             = 0x00cf;
    int OP_ADD_INT_LIT16                = 0x00d0;
    int OP_RSUB_INT                     = 0x00d1;
    int OP_MUL_INT_LIT16                = 0x00d2;
    int OP_DIV_INT_LIT16                = 0x00d3;
    int OP_REM_INT_LIT16                = 0x00d4;
    int OP_AND_INT_LIT16                = 0x00d5;
    int OP_OR_INT_LIT16                 = 0x00d6;
    int OP_XOR_INT_LIT16                = 0x00d7;
    int OP_ADD_INT_LIT8                 = 0x00d8;
    int OP_RSUB_INT_LIT8                = 0x00d9;
    int OP_MUL_INT_LIT8                 = 0x00da;
    int OP_DIV_INT_LIT8                 = 0x00db;
    int OP_REM_INT_LIT8                 = 0x00dc;
    int OP_AND_INT_LIT8                 = 0x00dd;
    int OP_OR_INT_LIT8                  = 0x00de;
    int OP_XOR_INT_LIT8                 = 0x00df;
    int OP_SHL_INT_LIT8                 = 0x00e0;
    int OP_SHR_INT_LIT8                 = 0x00e1;
    int OP_USHR_INT_LIT8                = 0x00e2;
    int OP_CONST_CLASS_JUMBO            = 0x00ff;
    int OP_CHECK_CAST_JUMBO             = 0x01ff;
    int OP_INSTANCE_OF_JUMBO            = 0x02ff;
    int OP_NEW_INSTANCE_JUMBO           = 0x03ff;
    int OP_NEW_ARRAY_JUMBO              = 0x04ff;
    int OP_FILLED_NEW_ARRAY_JUMBO       = 0x05ff;
    int OP_IGET_JUMBO                   = 0x06ff;
    int OP_IGET_WIDE_JUMBO              = 0x07ff;
    int OP_IGET_OBJECT_JUMBO            = 0x08ff;
    int OP_IGET_BOOLEAN_JUMBO           = 0x09ff;
    int OP_IGET_BYTE_JUMBO              = 0x0aff;
    int OP_IGET_CHAR_JUMBO              = 0x0bff;
    int OP_IGET_SHORT_JUMBO             = 0x0cff;
    int OP_IPUT_JUMBO                   = 0x0dff;
    int OP_IPUT_WIDE_JUMBO              = 0x0eff;
    int OP_IPUT_OBJECT_JUMBO            = 0x0fff;
    int OP_IPUT_BOOLEAN_JUMBO           = 0x10ff;
    int OP_IPUT_BYTE_JUMBO              = 0x11ff;
    int OP_IPUT_CHAR_JUMBO              = 0x12ff;
    int OP_IPUT_SHORT_JUMBO             = 0x13ff;
    int OP_SGET_JUMBO                   = 0x14ff;
    int OP_SGET_WIDE_JUMBO              = 0x15ff;
    int OP_SGET_OBJECT_JUMBO            = 0x16ff;
    int OP_SGET_BOOLEAN_JUMBO           = 0x17ff;
    int OP_SGET_BYTE_JUMBO              = 0x18ff;
    int OP_SGET_CHAR_JUMBO              = 0x19ff;
    int OP_SGET_SHORT_JUMBO             = 0x1aff;
    int OP_SPUT_JUMBO                   = 0x1bff;
    int OP_SPUT_WIDE_JUMBO              = 0x1cff;
    int OP_SPUT_OBJECT_JUMBO            = 0x1dff;
    int OP_SPUT_BOOLEAN_JUMBO           = 0x1eff;
    int OP_SPUT_BYTE_JUMBO              = 0x1fff;
    int OP_SPUT_CHAR_JUMBO              = 0x20ff;
    int OP_SPUT_SHORT_JUMBO             = 0x21ff;
    int OP_INVOKE_VIRTUAL_JUMBO         = 0x22ff;
    int OP_INVOKE_SUPER_JUMBO           = 0x23ff;
    int OP_INVOKE_DIRECT_JUMBO          = 0x24ff;
    int OP_INVOKE_STATIC_JUMBO          = 0x25ff;
    int OP_INVOKE_INTERFACE_JUMBO       = 0x26ff;
    // END(libcore-opcodes)

    /*
     * The rest of these are either generated by dexopt for optimized
     * code, or inserted by the VM at runtime.  They are never generated
     * by "dx".
     *
     * They are all deprecated and will be removed in a future
     * release, since these declarations are really of private implementation
     * details that are subject to change.
     */

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IGET_WIDE_VOLATILE           = 0xe8;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IPUT_WIDE_VOLATILE           = 0xe9;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_SGET_WIDE_VOLATILE           = 0xea;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_SPUT_WIDE_VOLATILE           = 0xeb;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_BREAKPOINT                   = 0xec;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_THROW_VERIFICATION_ERROR     = 0xed;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_EXECUTE_INLINE               = 0xee;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_EXECUTE_INLINE_RANGE         = 0xef;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_INVOKE_DIRECT_EMPTY          = 0xf0;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IGET_QUICK                   = 0xf2;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IGET_WIDE_QUICK              = 0xf3;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IGET_OBJECT_QUICK            = 0xf4;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IPUT_QUICK                   = 0xf5;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IPUT_WIDE_QUICK              = 0xf6;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_IPUT_OBJECT_QUICK            = 0xf7;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_INVOKE_VIRTUAL_QUICK         = 0xf8;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_INVOKE_VIRTUAL_QUICK_RANGE   = 0xf9;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_INVOKE_SUPER_QUICK           = 0xfa;

    /**
     * Implementation detail.
     * @deprecated Implementation detail.
     */
    @Deprecated int OP_INVOKE_SUPER_QUICK_RANGE     = 0xfb;
}
