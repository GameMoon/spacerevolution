var e;e||(e=typeof Module !== 'undefined' ? Module : {});var h={},k;for(k in e)e.hasOwnProperty(k)&&(h[k]=e[k]);e.arguments=[];e.thisProgram="./this.program";e.quit=function(a,b){throw b;};e.preRun=[];e.postRun=[];var m=!1,n=!1,q=!1,aa=!1;m="object"===typeof window;n="function"===typeof importScripts;q="object"===typeof process&&"function"===typeof require&&!m&&!n;aa=!m&&!q&&!n;var u="";function ba(a){return e.locateFile?e.locateFile(a,u):u+a}
if(q){u=__dirname+"/";var ca,da;e.read=function(a,b){ca||(ca=require("fs"));da||(da=require("path"));a=da.normalize(a);a=ca.readFileSync(a);return b?a:a.toString()};e.readBinary=function(a){a=e.read(a,!0);a.buffer||(a=new Uint8Array(a));assert(a.buffer);return a};1<process.argv.length&&(e.thisProgram=process.argv[1].replace(/\\/g,"/"));e.arguments=process.argv.slice(2);"undefined"!==typeof module&&(module.exports=e);process.on("uncaughtException",function(a){if(!(a instanceof w))throw a;});process.on("unhandledRejection",
x);e.quit=function(a){process.exit(a)};e.inspect=function(){return"[Emscripten Module object]"}}else if(aa)"undefined"!=typeof read&&(e.read=function(a){return read(a)}),e.readBinary=function(a){if("function"===typeof readbuffer)return new Uint8Array(readbuffer(a));a=read(a,"binary");assert("object"===typeof a);return a},"undefined"!=typeof scriptArgs?e.arguments=scriptArgs:"undefined"!=typeof arguments&&(e.arguments=arguments),"function"===typeof quit&&(e.quit=function(a){quit(a)});else if(m||n)n?
u=self.location.href:document.currentScript&&(u=document.currentScript.src),u=0!==u.indexOf("blob:")?u.substr(0,u.lastIndexOf("/")+1):"",e.read=function(a){var b=new XMLHttpRequest;b.open("GET",a,!1);b.send(null);return b.responseText},n&&(e.readBinary=function(a){var b=new XMLHttpRequest;b.open("GET",a,!1);b.responseType="arraybuffer";b.send(null);return new Uint8Array(b.response)}),e.readAsync=function(a,b,c){var d=new XMLHttpRequest;d.open("GET",a,!0);d.responseType="arraybuffer";d.onload=function(){200==
d.status||0==d.status&&d.response?b(d.response):c()};d.onerror=c;d.send(null)},e.setWindowTitle=function(a){document.title=a};var ea=e.print||("undefined"!==typeof console?console.log.bind(console):"undefined"!==typeof print?print:null),y=e.printErr||("undefined"!==typeof printErr?printErr:"undefined"!==typeof console&&console.warn.bind(console)||ea);for(k in h)h.hasOwnProperty(k)&&(e[k]=h[k]);h=void 0;function fa(a){var b;b||(b=16);return Math.ceil(a/b)*b}
var ha={"f64-rem":function(a,b){return a%b},"debugger":function(){debugger}},ia=!1;function assert(a,b){a||x("Assertion failed: "+b)}function ja(a){var b;if(0===b||!a)return"";for(var c=0,d,f=0;;){d=B[a+f>>0];c|=d;if(0==d&&!b)break;f++;if(b&&f==b)break}b||(b=f);d="";if(128>c){for(;0<b;)c=String.fromCharCode.apply(String,B.subarray(a,a+Math.min(b,1024))),d=d?d+c:c,a+=1024,b-=1024;return d}return D(B,a)}var ka="undefined"!==typeof TextDecoder?new TextDecoder("utf8"):void 0;
function D(a,b){for(var c=b;a[c];)++c;if(16<c-b&&a.subarray&&ka)return ka.decode(a.subarray(b,c));for(c="";;){var d=a[b++];if(!d)return c;if(d&128){var f=a[b++]&63;if(192==(d&224))c+=String.fromCharCode((d&31)<<6|f);else{var g=a[b++]&63;if(224==(d&240))d=(d&15)<<12|f<<6|g;else{var l=a[b++]&63;if(240==(d&248))d=(d&7)<<18|f<<12|g<<6|l;else{var p=a[b++]&63;if(248==(d&252))d=(d&3)<<24|f<<18|g<<12|l<<6|p;else{var v=a[b++]&63;d=(d&1)<<30|f<<24|g<<18|l<<12|p<<6|v}}}65536>d?c+=String.fromCharCode(d):(d-=
65536,c+=String.fromCharCode(55296|d>>10,56320|d&1023))}}else c+=String.fromCharCode(d)}}
function la(a,b,c,d){if(!(0<d))return 0;var f=c;d=c+d-1;for(var g=0;g<a.length;++g){var l=a.charCodeAt(g);if(55296<=l&&57343>=l){var p=a.charCodeAt(++g);l=65536+((l&1023)<<10)|p&1023}if(127>=l){if(c>=d)break;b[c++]=l}else{if(2047>=l){if(c+1>=d)break;b[c++]=192|l>>6}else{if(65535>=l){if(c+2>=d)break;b[c++]=224|l>>12}else{if(2097151>=l){if(c+3>=d)break;b[c++]=240|l>>18}else{if(67108863>=l){if(c+4>=d)break;b[c++]=248|l>>24}else{if(c+5>=d)break;b[c++]=252|l>>30;b[c++]=128|l>>24&63}b[c++]=128|l>>18&63}b[c++]=
128|l>>12&63}b[c++]=128|l>>6&63}b[c++]=128|l&63}}b[c]=0;return c-f}function ma(a){for(var b=0,c=0;c<a.length;++c){var d=a.charCodeAt(c);55296<=d&&57343>=d&&(d=65536+((d&1023)<<10)|a.charCodeAt(++c)&1023);127>=d?++b:b=2047>=d?b+2:65535>=d?b+3:2097151>=d?b+4:67108863>=d?b+5:b+6}return b}"undefined"!==typeof TextDecoder&&new TextDecoder("utf-16le");function na(a){var b=ma(a)+1,c=oa(b);la(a,E,c,b);return c}var buffer,E,B,G;
function pa(){e.HEAP8=E=new Int8Array(buffer);e.HEAP16=new Int16Array(buffer);e.HEAP32=G=new Int32Array(buffer);e.HEAPU8=B=new Uint8Array(buffer);e.HEAPU16=new Uint16Array(buffer);e.HEAPU32=new Uint32Array(buffer);e.HEAPF32=new Float32Array(buffer);e.HEAPF64=new Float64Array(buffer)}var qa,H,ra,sa,ta,ua,va;qa=H=ra=sa=ta=ua=va=0;
function wa(){x("Cannot enlarge memory arrays. Either (1) compile with  -s TOTAL_MEMORY=X  with X higher than the current value "+I+", (2) compile with  -s ALLOW_MEMORY_GROWTH=1  which allows increasing the size at runtime, or (3) if you want malloc to return NULL (0) instead of this abort, compile with  -s ABORTING_MALLOC=0 ")}var xa=e.TOTAL_STACK||5242880,I=e.TOTAL_MEMORY||16777216;I<xa&&y("TOTAL_MEMORY should be larger than TOTAL_STACK, was "+I+"! (TOTAL_STACK="+xa+")");
e.buffer?buffer=e.buffer:("object"===typeof WebAssembly&&"function"===typeof WebAssembly.Memory?(e.wasmMemory=new WebAssembly.Memory({initial:I/65536,maximum:I/65536}),buffer=e.wasmMemory.buffer):buffer=new ArrayBuffer(I),e.buffer=buffer);pa();function J(a){for(;0<a.length;){var b=a.shift();if("function"==typeof b)b();else{var c=b.hd;"number"===typeof c?void 0===b.sa?e.dynCall_v(c):e.dynCall_vi(c,b.sa):c(void 0===b.sa?null:b.sa)}}}var ya=[],za=[],Aa=[],Ba=[],Ca=[],Da=!1;
function Ea(){var a=e.preRun.shift();ya.unshift(a)}var K=0,Fa=null,L=null;e.preloadedImages={};e.preloadedAudios={};function Ga(a){return String.prototype.startsWith?a.startsWith("data:application/octet-stream;base64,"):0===a.indexOf("data:application/octet-stream;base64,")}
(function(){function a(){try{if(e.wasmBinary)return new Uint8Array(e.wasmBinary);if(e.readBinary)return e.readBinary(f);throw"both async and sync fetching of the wasm failed";}catch(t){x(t)}}function b(){return e.wasmBinary||!m&&!n||"function"!==typeof fetch?new Promise(function(b){b(a())}):fetch(f,{credentials:"same-origin"}).then(function(a){if(!a.ok)throw"failed to load wasm binary file at '"+f+"'";return a.arrayBuffer()}).catch(function(){return a()})}function c(a){function c(a){p=a.exports;if(p.memory){a=
p.memory;var b=e.buffer;a.byteLength<b.byteLength&&y("the new buffer in mergeMemory is smaller than the previous one. in native wasm, we should grow memory here");b=new Int8Array(b);(new Int8Array(a)).set(b);e.buffer=buffer=a;pa()}e.asm=p;e.usingWasm=!0;K--;e.monitorRunDependencies&&e.monitorRunDependencies(K);0==K&&(null!==Fa&&(clearInterval(Fa),Fa=null),L&&(a=L,L=null,a()))}function d(a){c(a.instance)}function A(a){b().then(function(a){return WebAssembly.instantiate(a,l)}).then(a,function(a){y("failed to asynchronously prepare wasm: "+
a);x(a)})}if("object"!==typeof WebAssembly)return y("no native wasm support detected"),!1;if(!(e.wasmMemory instanceof WebAssembly.Memory))return y("no native wasm Memory in use"),!1;a.memory=e.wasmMemory;l.global={NaN:NaN,Infinity:Infinity};l["global.Math"]=Math;l.env=a;K++;e.monitorRunDependencies&&e.monitorRunDependencies(K);if(e.instantiateWasm)try{return e.instantiateWasm(l,c)}catch(z){return y("Module.instantiateWasm callback failed with error: "+z),!1}e.wasmBinary||"function"!==typeof WebAssembly.instantiateStreaming||
Ga(f)||"function"!==typeof fetch?A(d):WebAssembly.instantiateStreaming(fetch(f,{credentials:"same-origin"}),l).then(d,function(a){y("wasm streaming compile failed: "+a);y("falling back to ArrayBuffer instantiation");A(d)});return{}}var d="main.wast",f="main.wasm",g="main.temp.asm.js";Ga(d)||(d=ba(d));Ga(f)||(f=ba(f));Ga(g)||(g=ba(g));var l={global:null,env:null,asm2wasm:ha,parent:e},p=null;e.asmPreload=e.asm;var v=e.reallocBuffer;e.reallocBuffer=function(a){if("asmjs"===r)var b=v(a);else a:{var c=
e.usingWasm?65536:16777216;0<a%c&&(a+=c-a%c);c=e.buffer.byteLength;if(e.usingWasm)try{b=-1!==e.wasmMemory.grow((a-c)/65536)?e.buffer=e.wasmMemory.buffer:null;break a}catch(A){b=null;break a}b=void 0}return b};var r="";e.asm=function(a,b){if(!b.table){a=e.wasmTableSize;void 0===a&&(a=1024);var d=e.wasmMaxTableSize;b.table="object"===typeof WebAssembly&&"function"===typeof WebAssembly.Table?void 0!==d?new WebAssembly.Table({initial:a,maximum:d,element:"anyfunc"}):new WebAssembly.Table({initial:a,element:"anyfunc"}):
Array(a);e.wasmTable=b.table}b.__memory_base||(b.__memory_base=e.STATIC_BASE);b.__table_base||(b.__table_base=0);b=c(b);assert(b,"no binaryen method succeeded.");return b}})();qa=1024;H=qa+23200;e.STATIC_BASE=qa;e.STATIC_BUMP=23200;H+=16;
var M={ea:1,W:2,Tc:3,Pb:4,ha:5,Da:6,ib:7,nc:8,V:9,wb:10,ya:11,cd:11,Ra:12,pa:13,Ib:14,zc:15,za:16,Aa:17,dd:18,ra:19,Ba:20,ia:21,N:22,ic:23,Qa:24,Z:25,$c:26,Jb:27,vc:28,ja:29,Qc:30,ac:31,Jc:32,Fb:33,Nc:34,rc:42,Mb:43,xb:44,Sb:45,Tb:46,Ub:47,$b:48,ad:49,lc:50,Rb:51,Cb:35,oc:37,ob:52,rb:53,ed:54,jc:55,sb:56,tb:57,Db:35,ub:59,xc:60,mc:61,Xc:62,wc:63,sc:64,tc:65,Pc:66,pc:67,lb:68,Uc:69,yb:70,Kc:71,cc:72,Gb:73,qb:74,Ec:76,pb:77,Oc:78,Vb:79,Wb:80,Zb:81,Yb:82,Xb:83,yc:38,Ca:39,dc:36,qa:40,Fc:95,Ic:96,Bb:104,
kc:105,mb:97,Mc:91,Cc:88,uc:92,Rc:108,Ab:111,jb:98,zb:103,hc:101,ec:100,Yc:110,Kb:112,Lb:113,Ob:115,nb:114,Eb:89,bc:90,Lc:93,Sc:94,kb:99,fc:102,Qb:106,Ac:107,Zc:109,bd:87,Hb:122,Vc:116,Dc:95,qc:123,Nb:84,Gc:75,vb:125,Bc:131,Hc:130,Wc:86};function Ha(a){e.___errno_location&&(G[e.___errno_location()>>2]=a);return a}
var Ia={0:"Success",1:"Not super-user",2:"No such file or directory",3:"No such process",4:"Interrupted system call",5:"I/O error",6:"No such device or address",7:"Arg list too long",8:"Exec format error",9:"Bad file number",10:"No children",11:"No more processes",12:"Not enough core",13:"Permission denied",14:"Bad address",15:"Block device required",16:"Mount device busy",17:"File exists",18:"Cross-device link",19:"No such device",20:"Not a directory",21:"Is a directory",22:"Invalid argument",23:"Too many open files in system",
24:"Too many open files",25:"Not a typewriter",26:"Text file busy",27:"File too large",28:"No space left on device",29:"Illegal seek",30:"Read only file system",31:"Too many links",32:"Broken pipe",33:"Math arg out of domain of func",34:"Math result not representable",35:"File locking deadlock error",36:"File or path name too long",37:"No record locks available",38:"Function not implemented",39:"Directory not empty",40:"Too many symbolic links",42:"No message of desired type",43:"Identifier removed",
44:"Channel number out of range",45:"Level 2 not synchronized",46:"Level 3 halted",47:"Level 3 reset",48:"Link number out of range",49:"Protocol driver not attached",50:"No CSI structure available",51:"Level 2 halted",52:"Invalid exchange",53:"Invalid request descriptor",54:"Exchange full",55:"No anode",56:"Invalid request code",57:"Invalid slot",59:"Bad font file fmt",60:"Device not a stream",61:"No data (for no delay io)",62:"Timer expired",63:"Out of streams resources",64:"Machine is not on the network",
65:"Package not installed",66:"The object is remote",67:"The link has been severed",68:"Advertise error",69:"Srmount error",70:"Communication error on send",71:"Protocol error",72:"Multihop attempted",73:"Cross mount point (not really error)",74:"Trying to read unreadable message",75:"Value too large for defined data type",76:"Given log. name not unique",77:"f.d. invalid for this operation",78:"Remote address changed",79:"Can   access a needed shared lib",80:"Accessing a corrupted shared lib",81:".lib section in a.out corrupted",
82:"Attempting to link in too many libs",83:"Attempting to exec a shared library",84:"Illegal byte sequence",86:"Streams pipe error",87:"Too many users",88:"Socket operation on non-socket",89:"Destination address required",90:"Message too long",91:"Protocol wrong type for socket",92:"Protocol not available",93:"Unknown protocol",94:"Socket type not supported",95:"Not supported",96:"Protocol family not supported",97:"Address family not supported by protocol family",98:"Address already in use",99:"Address not available",
100:"Network interface is not configured",101:"Network is unreachable",102:"Connection reset by network",103:"Connection aborted",104:"Connection reset by peer",105:"No buffer space available",106:"Socket is already connected",107:"Socket is not connected",108:"Can't send after socket shutdown",109:"Too many references",110:"Connection timed out",111:"Connection refused",112:"Host is down",113:"Host is unreachable",114:"Socket already connected",115:"Connection already in progress",116:"Stale file handle",
122:"Quota exceeded",123:"No medium (in tape drive)",125:"Operation canceled",130:"Previous owner died",131:"State not recoverable"};function Ka(a,b){for(var c=0,d=a.length-1;0<=d;d--){var f=a[d];"."===f?a.splice(d,1):".."===f?(a.splice(d,1),c++):c&&(a.splice(d,1),c--)}if(b)for(;c;c--)a.unshift("..");return a}function La(a){var b="/"===a.charAt(0),c="/"===a.substr(-1);(a=Ka(a.split("/").filter(function(a){return!!a}),!b).join("/"))||b||(a=".");a&&c&&(a+="/");return(b?"/":"")+a}
function Ma(a){var b=/^(\/?|)([\s\S]*?)((?:\.{1,2}|[^\/]+?|)(\.[^.\/]*|))(?:[\/]*)$/.exec(a).slice(1);a=b[0];b=b[1];if(!a&&!b)return".";b&&(b=b.substr(0,b.length-1));return a+b}function Na(a){if("/"===a)return"/";var b=a.lastIndexOf("/");return-1===b?a:a.substr(b+1)}function Oa(){var a=Array.prototype.slice.call(arguments,0);return La(a.join("/"))}function N(a,b){return La(a+"/"+b)}
function Pa(){for(var a="",b=!1,c=arguments.length-1;-1<=c&&!b;c--){b=0<=c?arguments[c]:"/";if("string"!==typeof b)throw new TypeError("Arguments to path.resolve must be strings");if(!b)return"";a=b+"/"+a;b="/"===b.charAt(0)}a=Ka(a.split("/").filter(function(a){return!!a}),!b).join("/");return(b?"/":"")+a||"."}var Qa=[];function Ra(a,b){Qa[a]={input:[],output:[],da:b};Sa(a,Ta)}
var Ta={open:function(a){var b=Qa[a.node.rdev];if(!b)throw new O(M.ra);a.tty=b;a.seekable=!1},close:function(a){a.tty.da.flush(a.tty)},flush:function(a){a.tty.da.flush(a.tty)},read:function(a,b,c,d){if(!a.tty||!a.tty.da.Ma)throw new O(M.Da);for(var f=0,g=0;g<d;g++){try{var l=a.tty.da.Ma(a.tty)}catch(p){throw new O(M.ha);}if(void 0===l&&0===f)throw new O(M.ya);if(null===l||void 0===l)break;f++;b[c+g]=l}f&&(a.node.timestamp=Date.now());return f},write:function(a,b,c,d){if(!a.tty||!a.tty.da.va)throw new O(M.Da);
try{for(var f=0;f<d;f++)a.tty.da.va(a.tty,b[c+f])}catch(g){throw new O(M.ha);}d&&(a.node.timestamp=Date.now());return f}},Va={Ma:function(a){if(!a.input.length){var b=null;if(q){var c=new Buffer(256),d=0,f=process.stdin.fd;if("win32"!=process.platform){var g=!1;try{f=fs.openSync("/dev/stdin","r"),g=!0}catch(l){}}try{d=fs.readSync(f,c,0,256,null)}catch(l){if(-1!=l.toString().indexOf("EOF"))d=0;else throw l;}g&&fs.closeSync(f);0<d?b=c.slice(0,d).toString("utf-8"):b=null}else"undefined"!=typeof window&&
"function"==typeof window.prompt?(b=window.prompt("Input: "),null!==b&&(b+="\n")):"function"==typeof readline&&(b=readline(),null!==b&&(b+="\n"));if(!b)return null;a.input=Ua(b,!0)}return a.input.shift()},va:function(a,b){null===b||10===b?(ea(D(a.output,0)),a.output=[]):0!=b&&a.output.push(b)},flush:function(a){a.output&&0<a.output.length&&(ea(D(a.output,0)),a.output=[])}},Wa={va:function(a,b){null===b||10===b?(y(D(a.output,0)),a.output=[]):0!=b&&a.output.push(b)},flush:function(a){a.output&&0<a.output.length&&
(y(D(a.output,0)),a.output=[])}},P={T:null,O:function(){return P.createNode(null,"/",16895,0)},createNode:function(a,b,c,d){if(24576===(c&61440)||4096===(c&61440))throw new O(M.ea);P.T||(P.T={dir:{node:{U:P.K.U,R:P.K.R,lookup:P.K.lookup,fa:P.K.fa,rename:P.K.rename,unlink:P.K.unlink,rmdir:P.K.rmdir,readdir:P.K.readdir,symlink:P.K.symlink},stream:{X:P.J.X}},file:{node:{U:P.K.U,R:P.K.R},stream:{X:P.J.X,read:P.J.read,write:P.J.write,Ea:P.J.Ea,Na:P.J.Na,ma:P.J.ma}},link:{node:{U:P.K.U,R:P.K.R,readlink:P.K.readlink},
stream:{}},Ga:{node:{U:P.K.U,R:P.K.R},stream:Xa}});c=Ya(a,b,c,d);16384===(c.mode&61440)?(c.K=P.T.dir.node,c.J=P.T.dir.stream,c.I={}):32768===(c.mode&61440)?(c.K=P.T.file.node,c.J=P.T.file.stream,c.L=0,c.I=null):40960===(c.mode&61440)?(c.K=P.T.link.node,c.J=P.T.link.stream):8192===(c.mode&61440)&&(c.K=P.T.Ga.node,c.J=P.T.Ga.stream);c.timestamp=Date.now();a&&(a.I[b]=c);return c},Wa:function(a){if(a.I&&a.I.subarray){for(var b=[],c=0;c<a.L;++c)b.push(a.I[c]);return b}return a.I},jd:function(a){return a.I?
a.I.subarray?a.I.subarray(0,a.L):new Uint8Array(a.I):new Uint8Array},Ha:function(a,b){a.I&&a.I.subarray&&b>a.I.length&&(a.I=P.Wa(a),a.L=a.I.length);if(!a.I||a.I.subarray){var c=a.I?a.I.length:0;c>=b||(b=Math.max(b,c*(1048576>c?2:1.125)|0),0!=c&&(b=Math.max(b,256)),c=a.I,a.I=new Uint8Array(b),0<a.L&&a.I.set(c.subarray(0,a.L),0))}else for(!a.I&&0<b&&(a.I=[]);a.I.length<b;)a.I.push(0)},$a:function(a,b){if(a.L!=b)if(0==b)a.I=null,a.L=0;else{if(!a.I||a.I.subarray){var c=a.I;a.I=new Uint8Array(new ArrayBuffer(b));
c&&a.I.set(c.subarray(0,Math.min(b,a.L)))}else if(a.I||(a.I=[]),a.I.length>b)a.I.length=b;else for(;a.I.length<b;)a.I.push(0);a.L=b}},K:{U:function(a){var b={};b.dev=8192===(a.mode&61440)?a.id:1;b.ino=a.id;b.mode=a.mode;b.nlink=1;b.uid=0;b.gid=0;b.rdev=a.rdev;16384===(a.mode&61440)?b.size=4096:32768===(a.mode&61440)?b.size=a.L:40960===(a.mode&61440)?b.size=a.link.length:b.size=0;b.atime=new Date(a.timestamp);b.mtime=new Date(a.timestamp);b.ctime=new Date(a.timestamp);b.$=4096;b.blocks=Math.ceil(b.size/
b.$);return b},R:function(a,b){void 0!==b.mode&&(a.mode=b.mode);void 0!==b.timestamp&&(a.timestamp=b.timestamp);void 0!==b.size&&P.$a(a,b.size)},lookup:function(){throw Za[M.W];},fa:function(a,b,c,d){return P.createNode(a,b,c,d)},rename:function(a,b,c){if(16384===(a.mode&61440)){try{var d=$a(b,c)}catch(g){}if(d)for(var f in d.I)throw new O(M.Ca);}delete a.parent.I[a.name];a.name=c;b.I[c]=a;a.parent=b},unlink:function(a,b){delete a.I[b]},rmdir:function(a,b){var c=$a(a,b),d;for(d in c.I)throw new O(M.Ca);
delete a.I[b]},readdir:function(a){var b=[".",".."],c;for(c in a.I)a.I.hasOwnProperty(c)&&b.push(c);return b},symlink:function(a,b,c){a=P.createNode(a,b,41471,0);a.link=c;return a},readlink:function(a){if(40960!==(a.mode&61440))throw new O(M.N);return a.link}},J:{read:function(a,b,c,d,f){var g=a.node.I;if(f>=a.node.L)return 0;a=Math.min(a.node.L-f,d);assert(0<=a);if(8<a&&g.subarray)b.set(g.subarray(f,f+a),c);else for(d=0;d<a;d++)b[c+d]=g[f+d];return a},write:function(a,b,c,d,f,g){if(!d)return 0;a=
a.node;a.timestamp=Date.now();if(b.subarray&&(!a.I||a.I.subarray)){if(g)return a.I=b.subarray(c,c+d),a.L=d;if(0===a.L&&0===f)return a.I=new Uint8Array(b.subarray(c,c+d)),a.L=d;if(f+d<=a.L)return a.I.set(b.subarray(c,c+d),f),d}P.Ha(a,f+d);if(a.I.subarray&&b.subarray)a.I.set(b.subarray(c,c+d),f);else for(g=0;g<d;g++)a.I[f+g]=b[c+g];a.L=Math.max(a.L,f+d);return d},X:function(a,b,c){1===c?b+=a.position:2===c&&32768===(a.node.mode&61440)&&(b+=a.node.L);if(0>b)throw new O(M.N);return b},Ea:function(a,b,
c){P.Ha(a.node,b+c);a.node.L=Math.max(a.node.L,b+c)},Na:function(a,b,c,d,f,g,l){if(32768!==(a.node.mode&61440))throw new O(M.ra);c=a.node.I;if(l&2||c.buffer!==b&&c.buffer!==b.buffer){if(0<f||f+d<a.node.L)c.subarray?c=c.subarray(f,f+d):c=Array.prototype.slice.call(c,f,f+d);a=!0;d=ab(d);if(!d)throw new O(M.Ra);b.set(c,d)}else a=!1,d=c.byteOffset;return{md:d,Sa:a}},ma:function(a,b,c,d,f){if(32768!==(a.node.mode&61440))throw new O(M.ra);if(f&2)return 0;P.J.write(a,b,0,d,c,!1);return 0}}},Q={ka:!1,bb:function(){Q.ka=
!!process.platform.match(/^win/);var a=process.binding("constants");a.fs&&(a=a.fs);Q.Ia={1024:a.O_APPEND,64:a.O_CREAT,128:a.O_EXCL,0:a.O_RDONLY,2:a.O_RDWR,4096:a.O_SYNC,512:a.O_TRUNC,1:a.O_WRONLY}},Fa:function(a){return Buffer.S?Buffer.from(a):new Buffer(a)},O:function(a){assert(q);return Q.createNode(null,"/",Q.La(a.ua.root),0)},createNode:function(a,b,c){if(16384!==(c&61440)&&32768!==(c&61440)&&40960!==(c&61440))throw new O(M.N);a=Ya(a,b,c);a.K=Q.K;a.J=Q.J;return a},La:function(a){try{var b=fs.lstatSync(a);
Q.ka&&(b.mode=b.mode|(b.mode&292)>>2)}catch(c){if(!c.code)throw c;throw new O(M[c.code]);}return b.mode},P:function(a){for(var b=[];a.parent!==a;)b.push(a.name),a=a.parent;b.push(a.O.ua.root);b.reverse();return Oa.apply(null,b)},Va:function(a){a&=-2656257;var b=0,c;for(c in Q.Ia)a&c&&(b|=Q.Ia[c],a^=c);if(a)throw new O(M.N);return b},K:{U:function(a){a=Q.P(a);try{var b=fs.lstatSync(a)}catch(c){if(!c.code)throw c;throw new O(M[c.code]);}Q.ka&&!b.$&&(b.$=4096);Q.ka&&!b.blocks&&(b.blocks=(b.size+b.$-
1)/b.$|0);return{dev:b.dev,ino:b.ino,mode:b.mode,nlink:b.nlink,uid:b.uid,gid:b.gid,rdev:b.rdev,size:b.size,atime:b.atime,mtime:b.mtime,ctime:b.ctime,$:b.$,blocks:b.blocks}},R:function(a,b){var c=Q.P(a);try{void 0!==b.mode&&(fs.chmodSync(c,b.mode),a.mode=b.mode),void 0!==b.size&&fs.truncateSync(c,b.size)}catch(d){if(!d.code)throw d;throw new O(M[d.code]);}},lookup:function(a,b){var c=N(Q.P(a),b);c=Q.La(c);return Q.createNode(a,b,c)},fa:function(a,b,c,d){a=Q.createNode(a,b,c,d);b=Q.P(a);try{16384===
(a.mode&61440)?fs.mkdirSync(b,a.mode):fs.writeFileSync(b,"",{mode:a.mode})}catch(f){if(!f.code)throw f;throw new O(M[f.code]);}return a},rename:function(a,b,c){a=Q.P(a);b=N(Q.P(b),c);try{fs.renameSync(a,b)}catch(d){if(!d.code)throw d;throw new O(M[d.code]);}},unlink:function(a,b){a=N(Q.P(a),b);try{fs.unlinkSync(a)}catch(c){if(!c.code)throw c;throw new O(M[c.code]);}},rmdir:function(a,b){a=N(Q.P(a),b);try{fs.rmdirSync(a)}catch(c){if(!c.code)throw c;throw new O(M[c.code]);}},readdir:function(a){a=Q.P(a);
try{return fs.readdirSync(a)}catch(b){if(!b.code)throw b;throw new O(M[b.code]);}},symlink:function(a,b,c){a=N(Q.P(a),b);try{fs.symlinkSync(c,a)}catch(d){if(!d.code)throw d;throw new O(M[d.code]);}},readlink:function(a){var b=Q.P(a);try{return b=fs.readlinkSync(b),b=bb.relative(bb.resolve(a.O.ua.root),b)}catch(c){if(!c.code)throw c;throw new O(M[c.code]);}}},J:{open:function(a){var b=Q.P(a.node);try{32768===(a.node.mode&61440)&&(a.ga=fs.openSync(b,Q.Va(a.flags)))}catch(c){if(!c.code)throw c;throw new O(M[c.code]);
}},close:function(a){try{32768===(a.node.mode&61440)&&a.ga&&fs.closeSync(a.ga)}catch(b){if(!b.code)throw b;throw new O(M[b.code]);}},read:function(a,b,c,d,f){if(0===d)return 0;try{return fs.readSync(a.ga,Q.Fa(b.buffer),c,d,f)}catch(g){throw new O(M[g.code]);}},write:function(a,b,c,d,f){try{return fs.writeSync(a.ga,Q.Fa(b.buffer),c,d,f)}catch(g){throw new O(M[g.code]);}},X:function(a,b,c){if(1===c)b+=a.position;else if(2===c&&32768===(a.node.mode&61440))try{b+=fs.fstatSync(a.ga).size}catch(d){throw new O(M[d.code]);
}if(0>b)throw new O(M.N);return b}}};H+=16;H+=16;H+=16;var cb=null,db={},R=[],eb=1,S=null,fb=!0,gb={},O=null,Za={};
function T(a,b){a=Pa("/",a);b=b||{};if(!a)return{path:"",node:null};var c={Ka:!0,wa:0},d;for(d in c)void 0===b[d]&&(b[d]=c[d]);if(8<b.wa)throw new O(M.qa);a=Ka(a.split("/").filter(function(a){return!!a}),!1);var f=cb;c="/";for(d=0;d<a.length;d++){var g=d===a.length-1;if(g&&b.parent)break;f=$a(f,a[d]);c=N(c,a[d]);f.la&&(!g||g&&b.Ka)&&(f=f.la.root);if(!g||b.Ja)for(g=0;40960===(f.mode&61440);)if(f=hb(c),c=Pa(Ma(c),f),f=T(c,{wa:b.wa}).node,40<g++)throw new O(M.qa);}return{path:c,node:f}}
function ib(a){for(var b;;){if(a===a.parent)return a=a.O.Oa,b?"/"!==a[a.length-1]?a+"/"+b:a+b:a;b=b?a.name+"/"+b:a.name;a=a.parent}}function jb(a,b){for(var c=0,d=0;d<b.length;d++)c=(c<<5)-c+b.charCodeAt(d)|0;return(a+c>>>0)%S.length}function kb(a){var b=jb(a.parent.id,a.name);a.Za=S[b];S[b]=a}function $a(a,b){var c;if(c=(c=lb(a,"x"))?c:a.K.lookup?0:M.pa)throw new O(c,a);for(c=S[jb(a.id,b)];c;c=c.Za){var d=c.name;if(c.parent.id===a.id&&d===b)return c}return a.K.lookup(a,b)}
function Ya(a,b,c,d){U||(U=function(a,b,c,d){a||(a=this);this.parent=a;this.O=a.O;this.la=null;this.id=eb++;this.name=b;this.mode=c;this.K={};this.J={};this.rdev=d},U.prototype={},Object.defineProperties(U.prototype,{read:{get:function(){return 365===(this.mode&365)},set:function(a){a?this.mode|=365:this.mode&=-366}},write:{get:function(){return 146===(this.mode&146)},set:function(a){a?this.mode|=146:this.mode&=-147}}}));a=new U(a,b,c,d);kb(a);return a}
var mb={r:0,rs:1052672,"r+":2,w:577,wx:705,xw:705,"w+":578,"wx+":706,"xw+":706,a:1089,ax:1217,xa:1217,"a+":1090,"ax+":1218,"xa+":1218};function nb(a){var b=["r","w","rw"][a&3];a&512&&(b+="w");return b}function lb(a,b){if(fb)return 0;if(-1===b.indexOf("r")||a.mode&292){if(-1!==b.indexOf("w")&&!(a.mode&146)||-1!==b.indexOf("x")&&!(a.mode&73))return M.pa}else return M.pa;return 0}function ob(a,b){try{return $a(a,b),M.Aa}catch(c){}return lb(a,"wx")}
function pb(){var a=4096;for(var b=0;b<=a;b++)if(!R[b])return b;throw new O(M.Qa);}function qb(a){V||(V=function(){},V.prototype={},Object.defineProperties(V.prototype,{object:{get:function(){return this.node},set:function(a){this.node=a}}}));var b=new V,c;for(c in a)b[c]=a[c];a=b;b=pb();a.fd=b;return R[b]=a}var Xa={open:function(a){a.J=db[a.node.rdev].J;a.J.open&&a.J.open(a)},X:function(){throw new O(M.ja);}};function Sa(a,b){db[a]={J:b}}
function rb(a,b){var c="/"===b,d=!b;if(c&&cb)throw new O(M.za);if(!c&&!d){var f=T(b,{Ka:!1});b=f.path;f=f.node;if(f.la)throw new O(M.za);if(16384!==(f.mode&61440))throw new O(M.Ba);}b={type:a,ua:{},Oa:b,Ya:[]};a=a.O(b);a.O=b;b.root=a;c?cb=a:f&&(f.la=b,f.O&&f.O.Ya.push(b))}function sb(a,b,c){var d=T(a,{parent:!0}).node;a=Na(a);if(!a||"."===a||".."===a)throw new O(M.N);var f=ob(d,a);if(f)throw new O(f);if(!d.K.fa)throw new O(M.ea);return d.K.fa(d,a,b,c)}function W(a){sb(a,16895,0)}
function tb(a,b,c){"undefined"===typeof c&&(c=b,b=438);sb(a,b|8192,c)}function ub(a,b){if(!Pa(a))throw new O(M.W);var c=T(b,{parent:!0}).node;if(!c)throw new O(M.W);b=Na(b);var d=ob(c,b);if(d)throw new O(d);if(!c.K.symlink)throw new O(M.ea);c.K.symlink(c,b,a)}function hb(a){a=T(a).node;if(!a)throw new O(M.W);if(!a.K.readlink)throw new O(M.N);return Pa(ib(a.parent),a.K.readlink(a))}
function vb(a,b){if(""===a)throw new O(M.W);if("string"===typeof b){var c=mb[b];if("undefined"===typeof c)throw Error("Unknown file open mode: "+b);b=c}var d=b&64?("undefined"===typeof d?438:d)&4095|32768:0;if("object"===typeof a)var f=a;else{a=La(a);try{f=T(a,{Ja:!(b&131072)}).node}catch(l){}}c=!1;if(b&64)if(f){if(b&128)throw new O(M.Aa);}else f=sb(a,d,0),c=!0;if(!f)throw new O(M.W);8192===(f.mode&61440)&&(b&=-513);if(b&65536&&16384!==(f.mode&61440))throw new O(M.Ba);if(!c&&(d=f?40960===(f.mode&
61440)?M.qa:16384===(f.mode&61440)&&("r"!==nb(b)||b&512)?M.ia:lb(f,nb(b)):M.W))throw new O(d);if(b&512){d=f;var g;"string"===typeof d?g=T(d,{Ja:!0}).node:g=d;if(!g.K.R)throw new O(M.ea);if(16384===(g.mode&61440))throw new O(M.ia);if(32768!==(g.mode&61440))throw new O(M.N);if(d=lb(g,"w"))throw new O(d);g.K.R(g,{size:0,timestamp:Date.now()})}b&=-641;f=qb({node:f,path:ib(f),flags:b,seekable:!0,position:0,J:f.J,hb:[],error:!1});f.J.open&&f.J.open(f);!e.logReadFiles||b&1||(wb||(wb={}),a in wb||(wb[a]=
1,console.log("FS.trackingDelegate error on read file: "+a)));try{gb.onOpenFile&&(g=0,1!==(b&2097155)&&(g|=1),0!==(b&2097155)&&(g|=2),gb.onOpenFile(a,g))}catch(l){console.log("FS.trackingDelegate['onOpenFile']('"+a+"', flags) threw an exception: "+l.message)}return f}function xb(a){if(null===a.fd)throw new O(M.V);a.ta&&(a.ta=null);try{a.J.close&&a.J.close(a)}catch(b){throw b;}finally{R[a.fd]=null}a.fd=null}
function yb(a,b,c){if(null===a.fd)throw new O(M.V);if(!a.seekable||!a.J.X)throw new O(M.ja);a.position=a.J.X(a,b,c);a.hb=[]}function zb(){O||(O=function(a,b){this.node=b;this.ab=function(a){this.ba=a;for(var b in M)if(M[b]===a){this.code=b;break}};this.ab(a);this.message=Ia[a];this.stack&&Object.defineProperty(this,"stack",{value:Error().stack,writable:!0})},O.prototype=Error(),O.prototype.constructor=O,[M.W].forEach(function(a){Za[a]=new O(a);Za[a].stack="<generic error, no stack>"}))}var Ab;
function Bb(a,b){var c=0;a&&(c|=365);b&&(c|=146);return c}
function Cb(a,b,c){a=N("/dev",a);var d=Bb(!!b,!!c);Db||(Db=64);var f=Db++<<8|0;Sa(f,{open:function(a){a.seekable=!1},close:function(){c&&c.buffer&&c.buffer.length&&c(10)},read:function(a,c,d,f){for(var g=0,l=0;l<f;l++){try{var p=b()}catch(C){throw new O(M.ha);}if(void 0===p&&0===g)throw new O(M.ya);if(null===p||void 0===p)break;g++;c[d+l]=p}g&&(a.node.timestamp=Date.now());return g},write:function(a,b,d,f){for(var g=0;g<f;g++)try{c(b[d+g])}catch(t){throw new O(M.ha);}f&&(a.node.timestamp=Date.now());
return g}});tb(a,d,f)}var Db,FS={},U,V,wb,Eb={},X=0;function Y(){X+=4;return G[X-4>>2]}function Fb(){var a=R[Y()];if(!a)throw new O(M.V);return a}var Gb={};function Hb(a){if(0===a)return 0;a=ja(a);if(!Gb.hasOwnProperty(a))return 0;Hb.S&&Ib(Hb.S);a=Gb[a];var b=ma(a)+1,c=ab(b);c&&la(a,E,c,b);Hb.S=c;return Hb.S}function Z(){Z.S||(Z.S=[]);Z.S.push(Jb());return Z.S.length-1}function Kb(a){return 0===a%4&&(0!==a%100||0===a%400)}function Lb(a,b){for(var c=0,d=0;d<=b;c+=a[d++]);return c}
var Mb=[31,29,31,30,31,30,31,31,30,31,30,31],Nb=[31,28,31,30,31,30,31,31,30,31,30,31];function Ob(a,b){for(a=new Date(a.getTime());0<b;){var c=a.getMonth(),d=(Kb(a.getFullYear())?Mb:Nb)[c];if(b>d-a.getDate())b-=d-a.getDate()+1,a.setDate(1),11>c?a.setMonth(c+1):(a.setMonth(0),a.setFullYear(a.getFullYear()+1));else{a.setDate(a.getDate()+b);break}}return a}
function Pb(a,b,c,d){function f(a,b,c){for(a="number"===typeof a?a.toString():a||"";a.length<b;)a=c[0]+a;return a}function g(a,b){return f(a,b,"0")}function l(a,b){function c(a){return 0>a?-1:0<a?1:0}var d;0===(d=c(a.getFullYear()-b.getFullYear()))&&0===(d=c(a.getMonth()-b.getMonth()))&&(d=c(a.getDate()-b.getDate()));return d}function p(a){switch(a.getDay()){case 0:return new Date(a.getFullYear()-1,11,29);case 1:return a;case 2:return new Date(a.getFullYear(),0,3);case 3:return new Date(a.getFullYear(),
0,2);case 4:return new Date(a.getFullYear(),0,1);case 5:return new Date(a.getFullYear()-1,11,31);case 6:return new Date(a.getFullYear()-1,11,30)}}function v(a){a=Ob(new Date(a.M+1900,0,1),a.oa);var b=p(new Date(a.getFullYear()+1,0,4));return 0>=l(p(new Date(a.getFullYear(),0,4)),a)?0>=l(b,a)?a.getFullYear()+1:a.getFullYear():a.getFullYear()-1}var r=G[d+40>>2];d={fb:G[d>>2],eb:G[d+4>>2],na:G[d+8>>2],aa:G[d+12>>2],Y:G[d+16>>2],M:G[d+20>>2],Pa:G[d+24>>2],oa:G[d+28>>2],nd:G[d+32>>2],cb:G[d+36>>2],gb:r?
ja(r):""};c=ja(c);r={"%c":"%a %b %d %H:%M:%S %Y","%D":"%m/%d/%y","%F":"%Y-%m-%d","%h":"%b","%r":"%I:%M:%S %p","%R":"%H:%M","%T":"%H:%M:%S","%x":"%m/%d/%y","%X":"%H:%M:%S"};for(var t in r)c=c.replace(new RegExp(t,"g"),r[t]);var F="Sunday Monday Tuesday Wednesday Thursday Friday Saturday".split(" "),C="January February March April May June July August September October November December".split(" ");r={"%a":function(a){return F[a.Pa].substring(0,3)},"%A":function(a){return F[a.Pa]},"%b":function(a){return C[a.Y].substring(0,
3)},"%B":function(a){return C[a.Y]},"%C":function(a){return g((a.M+1900)/100|0,2)},"%d":function(a){return g(a.aa,2)},"%e":function(a){return f(a.aa,2," ")},"%g":function(a){return v(a).toString().substring(2)},"%G":function(a){return v(a)},"%H":function(a){return g(a.na,2)},"%I":function(a){a=a.na;0==a?a=12:12<a&&(a-=12);return g(a,2)},"%j":function(a){return g(a.aa+Lb(Kb(a.M+1900)?Mb:Nb,a.Y-1),3)},"%m":function(a){return g(a.Y+1,2)},"%M":function(a){return g(a.eb,2)},"%n":function(){return"\n"},
"%p":function(a){return 0<=a.na&&12>a.na?"AM":"PM"},"%S":function(a){return g(a.fb,2)},"%t":function(){return"\t"},"%u":function(a){return(new Date(a.M+1900,a.Y+1,a.aa,0,0,0,0)).getDay()||7},"%U":function(a){var b=new Date(a.M+1900,0,1),c=0===b.getDay()?b:Ob(b,7-b.getDay());a=new Date(a.M+1900,a.Y,a.aa);return 0>l(c,a)?g(Math.ceil((31-c.getDate()+(Lb(Kb(a.getFullYear())?Mb:Nb,a.getMonth()-1)-31)+a.getDate())/7),2):0===l(c,b)?"01":"00"},"%V":function(a){var b=p(new Date(a.M+1900,0,4)),c=p(new Date(a.M+
1901,0,4)),d=Ob(new Date(a.M+1900,0,1),a.oa);return 0>l(d,b)?"53":0>=l(c,d)?"01":g(Math.ceil((b.getFullYear()<a.M+1900?a.oa+32-b.getDate():a.oa+1-b.getDate())/7),2)},"%w":function(a){return(new Date(a.M+1900,a.Y+1,a.aa,0,0,0,0)).getDay()},"%W":function(a){var b=new Date(a.M,0,1),c=1===b.getDay()?b:Ob(b,0===b.getDay()?1:7-b.getDay()+1);a=new Date(a.M+1900,a.Y,a.aa);return 0>l(c,a)?g(Math.ceil((31-c.getDate()+(Lb(Kb(a.getFullYear())?Mb:Nb,a.getMonth()-1)-31)+a.getDate())/7),2):0===l(c,b)?"01":"00"},
"%y":function(a){return(a.M+1900).toString().substring(2)},"%Y":function(a){return a.M+1900},"%z":function(a){a=a.cb;var b=0<=a;a=Math.abs(a)/60;return(b?"+":"-")+String("0000"+(a/60*100+a%60)).slice(-4)},"%Z":function(a){return a.gb},"%%":function(){return"%"}};for(t in r)0<=c.indexOf(t)&&(c=c.replace(new RegExp(t,"g"),r[t](d)));t=Ua(c,!1);if(t.length>b)return 0;E.set(t,a);return t.length-1}zb();S=Array(4096);rb(P,"/");W("/tmp");W("/home");W("/home/web_user");
(function(){W("/dev");Sa(259,{read:function(){return 0},write:function(a,b,f,g){return g}});tb("/dev/null",259);Ra(1280,Va);Ra(1536,Wa);tb("/dev/tty",1280);tb("/dev/tty1",1536);if("undefined"!==typeof crypto){var a=new Uint8Array(1);var b=function(){crypto.getRandomValues(a);return a[0]}}else q?b=function(){return require("crypto").randomBytes(1)[0]}:b=function(){x("random_device")};Cb("random",b);Cb("urandom",b);W("/dev/shm");W("/dev/shm/tmp")})();W("/proc");W("/proc/self");W("/proc/self/fd");
rb({O:function(){var a=Ya("/proc/self","fd",16895,73);a.K={lookup:function(a,c){var b=R[+c];if(!b)throw new O(M.V);a={parent:null,O:{Oa:"fake"},K:{readlink:function(){return b.path}}};return a.parent=a}};return a}},"/proc/self/fd");
za.unshift(function(){if(!e.noFSInit&&!Ab){assert(!Ab,"FS.init was previously called. If you want to initialize later with custom parameters, remove any earlier calls (note that one is automatically added to the generated code)");Ab=!0;zb();e.stdin=e.stdin;e.stdout=e.stdout;e.stderr=e.stderr;e.stdin?Cb("stdin",e.stdin):ub("/dev/tty","/dev/stdin");e.stdout?Cb("stdout",null,e.stdout):ub("/dev/tty","/dev/stdout");e.stderr?Cb("stderr",null,e.stderr):ub("/dev/tty1","/dev/stderr");var a=vb("/dev/stdin",
"r");assert(0===a.fd,"invalid handle for stdin ("+a.fd+")");a=vb("/dev/stdout","w");assert(1===a.fd,"invalid handle for stdout ("+a.fd+")");a=vb("/dev/stderr","w");assert(2===a.fd,"invalid handle for stderr ("+a.fd+")")}});Aa.push(function(){fb=!1});Ba.push(function(){Ab=!1;var a=e._fflush;a&&a(0);for(a=0;a<R.length;a++){var b=R[a];b&&xb(b)}});za.unshift(function(){});Ba.push(function(){});if(q){var fs=require("fs"),bb=require("path");Q.bb()}var Qb=H;H=H+4+15&-16;va=Qb;ra=sa=fa(H);ta=ra+xa;ua=fa(ta);
G[va>>2]=ua;function Ua(a,b){var c=Array(ma(a)+1);a=la(a,c,0,c.length);b&&(c.length=a);return c}e.wasmTableSize=478;e.wasmMaxTableSize=478;e.Ta={};
e.Ua={d:x,x:function(){wa()},s:function(){return I},p:wa,o:function(){return!!Rb.gd},j:function(){},n:function(){Ha(M.ea);return-1},i:Ha,m:function(a,b){X=b;try{var c=Fb();Y();var d=Y(),f=Y(),g=Y();yb(c,d,g);G[f>>2]=c.position;c.ta&&0===d&&0===g&&(c.ta=null);return 0}catch(l){return"undefined"!==typeof FS&&l instanceof O||x(l),-l.ba}},l:function(a,b){X=b;try{var c=Fb(),d=Y();a:{var f=Y();for(b=a=0;b<f;b++){var g=G[d+(8*b+4)>>2],l=c,p=G[d+8*b>>2],v=g,r=void 0,t=E;if(0>v||0>r)throw new O(M.N);if(null===
l.fd)throw new O(M.V);if(1===(l.flags&2097155))throw new O(M.V);if(16384===(l.node.mode&61440))throw new O(M.ia);if(!l.J.read)throw new O(M.N);var F="undefined"!==typeof r;if(!F)r=l.position;else if(!l.seekable)throw new O(M.ja);var C=l.J.read(l,t,p,v,r);F||(l.position+=C);var A=C;if(0>A){var z=-1;break a}a+=A;if(A<g)break}z=a}return z}catch(Ja){return"undefined"!==typeof FS&&Ja instanceof O||x(Ja),-Ja.ba}},k:function(a,b){X=b;try{var c=Fb(),d=Y();a:{var f=Y();for(b=a=0;b<f;b++){var g=c,l=G[d+8*b>>
2],p=G[d+(8*b+4)>>2],v=E,r=void 0;if(0>p||0>r)throw new O(M.N);if(null===g.fd)throw new O(M.V);if(0===(g.flags&2097155))throw new O(M.V);if(16384===(g.node.mode&61440))throw new O(M.ia);if(!g.J.write)throw new O(M.N);g.flags&1024&&yb(g,0,2);var t="undefined"!==typeof r;if(!t)r=g.position;else if(!g.seekable)throw new O(M.ja);var F=g.J.write(g,v,l,p,r,void 0);t||(g.position+=F);try{if(g.path&&gb.onWriteToFile)gb.onWriteToFile(g.path)}catch(z){console.log("FS.trackingDelegate['onWriteToFile']('"+path+
"') threw an exception: "+z.message)}var C=F;if(0>C){var A=-1;break a}a+=C}A=a}return A}catch(z){return"undefined"!==typeof FS&&z instanceof O||x(z),-z.ba}},w:function(a,b){X=b;try{var c=Fb(),d=Y();switch(d){case 21509:case 21505:return c.tty?0:-M.Z;case 21510:case 21511:case 21512:case 21506:case 21507:case 21508:return c.tty?0:-M.Z;case 21519:if(!c.tty)return-M.Z;var f=Y();return G[f>>2]=0;case 21520:return c.tty?-M.N:-M.Z;case 21531:a=f=Y();if(!c.J.Xa)throw new O(M.Z);return c.J.Xa(c,d,a);case 21523:return c.tty?
0:-M.Z;case 21524:return c.tty?0:-M.Z;default:x("bad ioctl syscall "+d)}}catch(g){return"undefined"!==typeof FS&&g instanceof O||x(g),-g.ba}},v:function(a,b){X=b;try{var c=Fb();xb(c);return 0}catch(d){return"undefined"!==typeof FS&&d instanceof O||x(d),-d.ba}},u:function(a,b){X=b;try{var c=Y(),d=Y(),f=Eb[c];if(!f)return 0;if(d===f.kd){var g=R[f.fd],l=f.flags,p=new Uint8Array(B.subarray(c,c+d));g&&g.J.ma&&g.J.ma(g,p,0,d,l);Eb[c]=null;f.Sa&&Ib(f.ld)}return 0}catch(v){return"undefined"!==typeof FS&&
v instanceof O||x(v),-v.ba}},h:function(){},c:function(){e.abort()},t:function(a,b,c){B.set(B.subarray(b,b+c),a);return a},g:Hb,f:function(a){var b=Z.S[a];Z.S.splice(a,1);Sb(b)},e:Z,r:function(){return 0},q:function(a,b,c,d){return Pb(a,b,c,d)},a:va,b:sa};var Tb=e.asm(e.Ta,e.Ua,buffer);e.asm=Tb;var Rb=e.__ZSt18uncaught_exceptionv=function(){return e.asm.y.apply(null,arguments)};e.___errno_location=function(){return e.asm.z.apply(null,arguments)};
var Ib=e._free=function(){return e.asm.A.apply(null,arguments)};e._main=function(){return e.asm.B.apply(null,arguments)};var ab=e._malloc=function(){return e.asm.C.apply(null,arguments)},oa=e.stackAlloc=function(){return e.asm.F.apply(null,arguments)},Sb=e.stackRestore=function(){return e.asm.G.apply(null,arguments)},Jb=e.stackSave=function(){return e.asm.H.apply(null,arguments)};e.dynCall_v=function(){return e.asm.D.apply(null,arguments)};e.dynCall_vi=function(){return e.asm.E.apply(null,arguments)};
e.asm=Tb;function w(a){this.name="ExitStatus";this.message="Program terminated with exit("+a+")";this.status=a}w.prototype=Error();w.prototype.constructor=w;L=function Ub(){e.calledRun||Vb();e.calledRun||(L=Ub)};
e.callMain=function(a){a=a||[];Da||(Da=!0,J(za));var b=a.length+1,c=oa(4*(b+1));G[c>>2]=na(e.thisProgram);for(var d=1;d<b;d++)G[(c>>2)+d]=na(a[d-1]);G[(c>>2)+b]=0;try{var f=e._main(b,c,0);if(!e.noExitRuntime||0!==f){if(!e.noExitRuntime&&(ia=!0,sa=void 0,J(Ba),e.onExit))e.onExit(f);e.quit(f,new w(f))}}catch(g){g instanceof w||("SimulateInfiniteLoop"==g?e.noExitRuntime=!0:((a=g)&&"object"===typeof g&&g.stack&&(a=[g,g.stack]),y("exception thrown: "+a),e.quit(1,g)))}finally{}};
function Vb(a){function b(){if(!e.calledRun&&(e.calledRun=!0,!ia)){Da||(Da=!0,J(za));J(Aa);if(e.onRuntimeInitialized)e.onRuntimeInitialized();e._main&&Wb&&e.callMain(a);if(e.postRun)for("function"==typeof e.postRun&&(e.postRun=[e.postRun]);e.postRun.length;){var b=e.postRun.shift();Ca.unshift(b)}J(Ca)}}a=a||e.arguments;if(!(0<K)){if(e.preRun)for("function"==typeof e.preRun&&(e.preRun=[e.preRun]);e.preRun.length;)Ea();J(ya);0<K||e.calledRun||(e.setStatus?(e.setStatus("Running..."),setTimeout(function(){setTimeout(function(){e.setStatus("")},
1);b()},1)):b())}}e.run=Vb;function x(a){if(e.onAbort)e.onAbort(a);void 0!==a?(ea(a),y(a),a=JSON.stringify(a)):a="";ia=!0;throw"abort("+a+"). Build with -s ASSERTIONS=1 for more info.";}e.abort=x;if(e.preInit)for("function"==typeof e.preInit&&(e.preInit=[e.preInit]);0<e.preInit.length;)e.preInit.pop()();var Wb=!0;e.noInitialRun&&(Wb=!1);e.noExitRuntime=!0;Vb();
