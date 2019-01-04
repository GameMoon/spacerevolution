@echo off
cls
echo Build
@echo on
start /I /W build.bat emcc
@echo off
echo Run
@echo on
start python -m http.server 8080
start python -m SimpleHTTPServer 8080
start http://localhost:8080/index.html
pause
EXIT