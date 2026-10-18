# Backseating Allowed Unity Template

This is the template project for Unity-based submissions to the [Backseating Allowed Game Jam 2026](https://itch.io/jam/backseating-allowed-jam-2026)! It uses [Tentacle](https://tentacle.live/) for integrations with the Twitch API to make your project respond to viewer actions during streams.

This was built with Unity 6.3, but Tentacle is known to support versions as low as 2020.3. Contact **JustInvoke** on the jam [Discord server](https://discord.gg/8eQxSGeAbm) if you need the project backported to an earlier version.

The Tentacle version in use is 1.2.0-alpha since that supports the embedded version of the plugin (may be updated later). [See documentation](https://tentacle.live/docs/1.2.0-alpha/unity/)

## Contents

The **Assets/Demo** folder contains the Demo Scene, scripts, and prefabs. The demo is just a chat log displaying a live feed of the chat associated with the signed in account, and an input field for sending chat messages directly from the game. When the game is running, a connect button appears in the top right to enable signing in which is required for Twitch functionality to work.

The **Assets/Resources** folder contains the TentacleSettings file that can be left alone for most projects and is already configured to work in builds. This is required for your project beyond the demo.

**Assets/Settings** contains general settings for [URP (Universal Render Pipeline)](https://docs.unity3d.com/6000.3/Documentation/Manual/urp/urp-reference-landing.html).

**Assets/TextMesh Pro** contains general resources for UI text (recommended for most projects using [uGUI](https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/index.html)).

## How to use

Clone or download the repository and open it with the [Unity Hub](https://docs.unity.com/en-us/hub) (Add > Add project from disk). It should prompt you to download the correct Unity version (6000.3.16f1) if you don't already have it installed.

The main components necessary for quick integration are **TentacleEventRelay**, and **ConnectionsWidget** or **SignInButton**.

[**TentacleEventRelay**](https://tentacle.live/docs/1.2.0-alpha/unity/reference/types#tentacleeventrelay) exposes events you can hook up to functions in your own code such as chat messages, follows, subs, and more. The demo only uses **OnChatMessage** to call **ChatLog.OnChatMessageReceived** as an example, which you could expand on to parse custom commands from viewers.

See the [documentation](https://tentacle.live/docs/1.2.0-alpha/unity/stream#receiving-stream-events) for more info on how to subscribe to Twitch events in your own code.

[**ConnectionsWidget**](https://tentacle.live/docs/1.2.0-alpha/unity/reference/types#connectionswidget) is a basic component that dynamically creates a button for signing into Twitch in a browser window to grant necessary permissions. It also shows the connection status with some extra text. In the demo scene you can find this in the hierarchy under **Canvas > DemoRoot > ConnectionBar > ConnectionWidget**.

[**SignInButton**](https://tentacle.live/docs/1.2.0-alpha/unity/reference/types#signinbutton) is a simpler component you can place on any uGUI button, and it will optionally update that button's text based on the connection status. Use this if you want more control over the appearance of the sign-in process.

You can also write your own sign-in method with some [asynchronous programming](https://tentacle.live/docs/1.2.0-alpha/unity/reference/types#tentacle-connections-method-signinasync) if comfortable. *Your game must have some means of signing in for Twitch interactivity to work.*

## Support

Contact **JustInvoke** on the official [**Discord server**](https://discord.gg/8eQxSGeAbm) if you need help with Unity and Tentacle integration.
