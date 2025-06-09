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
<h3>SETUP</h3>
<p>after installing vRez in your project:</p>
<p>-Add: using vRez</p>
<p>-create a VRezManager</p>
<p>in Initialize, after: base.Initialize();</p>
<p>-initialize the VRezManager: vrez = new VRezManager(GraphicsDevice, Window, "your virtual width", "your virtual Height");</p>
<p>then in your Draw method:</p>
<p>-use: vrez.BeginDraw(GraphicsDevice); before your batch begin</p>
<p>-to render to the window again you can use: vrez.EndDraw(spriteBatch, GraphicsDevice);</p>
<p>anything after that will be drawn to the actual window</p>

<h3>COORDINATE CONVERTION</h3>
<p>mouse coordinates example:</p>
<p>mouseState = Mouse.GetState();</p>
<p>mousePos = vrez.ScreenToVirtual(new(mouseState.X, mouseState.Y));</p>