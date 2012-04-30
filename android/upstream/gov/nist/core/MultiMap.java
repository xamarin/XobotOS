package gov.nist.core;

/*
 * Copyright 1999-2004 The Apache Software Foundation
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

import java.util.Map;

/** 
 * This is simply a Map with slightly different semantics.
 * Instead of returning an Object, it returns a Collection.
 * So for example, you can put( key, new Integer(1) ); 
 * and then a Object get( key ); will return you a Collection 
 * instead of an Integer.
 * Thus, this is simply a tag interface.
 *
 * @since 2.0
 * @author Christopher Berry
 * @author <a href="mailto:jstrachan@apache.org">James Strachan</a>
 */
public interface MultiMap extends Map {
    
    public Object remove( Object key, Object item );
   
}
