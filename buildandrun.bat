@echo off
cls
echo Build
@echo on

start /I /W emcc main.cpp -s WASM=1 -o main.html
@echo off
echo Run
@echo on
start main.html
EXIT