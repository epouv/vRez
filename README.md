# vRez

**vRez** is a lightweight virtual resolution rendering system for MonoGame.

## Features
- Set your desired fixed resolution and let vRez scale it to the screen
- Handles aspect ratio and letterboxing
- Provides coordinates convertion from screen to virtual space
- Easy-to-use API

## Installation
`dotnet add package vRez`

## Usage
SETUP
after installing vRez in your project:
-Add: using vRez
-create a VRezManager
in Initialize, after: base.Initialize();
-initialize the VRezManager: vrez = new VRezManager(GraphicsDevice, Window, "your virtual width",           "your virtual Height");
then in your Draw method:
-use: vrez.BeginDraw(GraphicsDevice); before your batch begin
-to render to the window again you can use: vrez.EndDraw(spriteBatch, GraphicsDevice);
anything after that will be drawn to the actual window

COORDINATE CONVERTION
mouse coordinates example:
    mouseState = Mouse.GetState();
    mousePos = vrez.ScreenToVirtual(new(mouseState.X, mouseState.Y));