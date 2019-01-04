@echo off
cls
echo Build
@echo on

start /I /W build.bat emcc
@echo off
echo Run
@echo on
start index.html
EXIT