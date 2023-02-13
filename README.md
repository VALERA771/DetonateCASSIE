![Github All Downloads](https://img.shields.io/github/downloads/VALERA771/DetonateCassie/total.svg?style=flat)

# DetonateCASSIE
Sends a CASSIE message after a countdown starts and can start a customable auto-nuke

# Config values
|Name|Default value|Description|
|----|-------------|-----------|
|is_enabled|true|Indicates whenever is plugin enabled|
|debug|false|Debug mode with logs in LA console|
|auto_nuke|false|Should auto-nuke be enabled?|
|activationg_minutes|20|Time (in minutes) when auto-nuke should start|
|is_cancelable|false|Can auto-nuke be cancelled?|
|every_start|false|Should CASSIE be send on every warhead start (true) or only on auto-nuke (false)|
|cassie_message|Alpha warhead has been Detonated|Text for CASSIE|
|is_subtiteled|false|Should CASSIE be subtiteled?|

# Installation
Put DetonateCASSIE.dll into
 - Linux: /home/<user>/.config/EXILED/Plugins
 - Windows: C:\Users\<user>\AppData\Roaming\EXILED\Plugins
and restart a server
