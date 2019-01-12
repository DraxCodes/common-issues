<p align="center">
    <img src="../../Images/DataStorage-Json.png">
</p>

# What is JSON

In computing, JavaScript Object Notation is an open-standard file format that uses human-readable text to transmit data objects consisting of attribute–value pairs and array data types.

Or put simply, JSON is a readable file format that can be used to store data. This data normally consists of a key `"My Key"` and a value `"My Value"`.

## Why should I use it

Ideally this is a question you should be answering yourself. However one of the main reasons it is used is because, JSON allows you to store data that will persist for as-long as you need it. This is why it often coins the term "Persistant Data Storage". You should use it at your own discretion as you see fit.

## When should I Use it

As above this is a question more for yourself than this guide. However the main time you will want to use this is when you want to save/store some data that isn't going to disapear as soon as the bot restarts. It also allows you to store large quantities of data which may otherwise bog your porject down.

## How to use it

How to use it breaks down into 3 main aspects. These are the main things to learn about when working with JSON.

- Generating JSON Data. [Link](#Generating)
  - The actual creation of the JSON data itself.
- Loading JSON Data (Deserialize). [Link](#Loading)
  - Loading already generated JSON Data into your project.
- Saving JSON Data  (Serialize). [Link](#Saving)
  - This links in with generating JSON Data however we keep it seperate as it would also include things like modifying the data and re-saving it.

### Generating

Generating the JSON data is actually quite simple. You can do it in many different ways, however I will explain the main two ways.

#### Generating From Template

This is easily the best way to go about generating JSON data to work with. I'm going to go over the steps you need to do to get the hang of how this works.

##### Notes

- This is going to be a basic example however a little understanding of C# is required.
- I expect you to understand how to use Visual Studio IDE or your prefered IDE/Code Editor already.

##### Setting up a new project to generate the template

We need to setup a new project (preferably a console project) to actually generate the template. While this isn't a requirement, it will make generating the template so much easier.

1. In your new project, you first want to install the Nuget Package named `Newtonsoft Json`.
2. Now create an object or structure for the data you're storing. We will be storing a `Prefix`, a `DiscordToken` and a `Now Playing` status. (see example below)
   - **Note**: This will preferably be in a new file with a class name that fits the type of data you're storing.
   - I will be naming my class `BotConfig`

```cs
public class BotConfig
{
    public string DiscordToken { get; set; }
    public string Prefix { get; set; }
    public string NowPlaying { get; set; }
}
```

Notice how in the above example I make everything `public` this is important as it's what's going to allow us to use these properties and this object. Essentially this is exactly what data we're going to be storing and loading. the type of data for all of these is `string` and the name (such as `DiscordToken`) is the key or attribute we're going to give that value.

3. Now in your `Program.cs` in the `Main` method. You're going to want to create a new instance of this class like below.

```cs
var botConfig = new BotConfig();
```

4. Now we need to assign some values to this new `BotConfig` object.
   - You can do that in a few ways, I like to do it like below. 

```cs
var botConfig = new BotConfig
    {
        DiscordToken = "MyTokenskfasiufskaj09834jsadf",
        Prefix = "!",
        NowPlaying = "Making a new guide"
    };
```

5. Next we want to turn this object into some JSON data. To do that, first add the using statement `using NewtonSoft.Json;` Then you want to do what's called Serializing the data.
   - We Format with `Formatting.Indented` to make the file more readable.

```cs
var newJson = JsonConvert.SerializeObject(botConfig, Formatting.Indented);
```

6. Now we can write the information to a file. Idealy this is where you want to implement some form of check to see if your JSON file already exists or not.
   - This method below will create the file if it doesn't exist, or it will overwrite the file if it does.

```cs
File.WriteAllText("config.json", newJson, new UTF8Encoding(false));
```

7. Now all being well, you should have a new file in your `bin > Debug > Netcore` folder named `config.json`. As you can see it's created a basic template that you can now fill in and use as you see fit.

```json
{
  "DiscordToken": "MyTokenskfasiufskaj09834jsadf",
  "Prefix": "!",
  "NowPlaying": "Making a new guide"
}
```

You can use this sort of template making guide for all sorts of different situations. Maybe you don't want a complex object, instead you just want a bunch of strings. Well you can do that too

```cs
//Create our temp list of strings
var myStrings = new List<string>() { "String 1", "String 2", "String 3" };

//Serialize this new temp data
var stringJson = JsonConvert.SerializeObject(myStrings);

//Write it to a file
File.WriteAllText("mystrings.json", stringJson, new UTF8Encoding(false));
```

#### Generating By Hand

Generating by hand is probably one of the harder ways to generate JSON data. This is because it requires you have a certain amount of understanding of JSON file formatting to accomplish. That being said there are tools available (Below) which can help you in this process.

- [https://www.json-generator.com](https://next.json-generator.com/)
- [http://www.objgen.com/json](http://www.objgen.com/json)
- [https://www.jsonschema.net/](https://www.jsonschema.net/)

---

### Loading

Loading JSON data is very simple, it's pretty much the oposite of what we did above when we serialize the data. Instead of a step by step guide, use the comments below to understand what's going on.

```cs
//Read our JSON file and save it as a variable. (I like to call this RawData)
var rawData = File.ReadAllText("config.json");

//Now we have our json data as one big string.
//We can use Deserialize to convert it into something we understand.
//Using our Object Example from Before:
var myBotConfig = JsonConvert.DeserializeObject<BotConfig>(rawData);

//Now we have access to all values we set before
var token = myBotConfig.DiscordToken;
var prefix = myBotConfig.Prefix;
var nowPlaying = myBotConfig.NowPlaying;

//Using the basic List of Strings example:
var myListStrings = JsonConvert.DeserializeObject<List<string>>(rawData);
//Now we have access to all the strings (As a Type: List<string>)
```

---

### Saving

You essentially already know how to save data from the [Generating A Template](#Generating) guide above. So here I will quickly cover Editing the data and the saving it again. Im going to use the Object example as it's simpler to understand.

Again I am going to leave this section as all comments as it's pretty self explanitory.

```cs
//First lets load our data we have saved.
var rawData = File.ReadAllText("config.json");

//Now we deserialize it using our BotConfig Object from before.
var myBotConfig = JsonConvert.DeserializeObject<BotConfig>(rawData);

//Now we're going to edit some data.
//Let's say for example, you have a command that updates the "Now Playing" status.
myBotConfig.NowPlaying = "Something Else";

//Now that is edited we can Serialize the Object again
var newJson = JsonConvert.SerializeObject(myBotConfig, Formatting.Indented);

//Now overwrite the old file with new data
File.WriteAllText("config.json", newJson, new UTF8Encoding(false));
```

As you can see, to edit and save new data in a JSON file is very simple. You essentially Deserialize the old data, edit what needs to be edited, serialize it again, save the file so it overwrites the old.

---

That's it for this guide. If none of the above guide covers your current issue, jump into our discord (Link Below) and ask for help. If you don't want to use Discord, you can use the link [HERE](https://github.com/discord-bot-tutorial/common-issues/issues) to open a new issue directly from this github repo, this will send a notification to our discord server where one of the many Helpers we have can get back to you.

Author: Draxis#0359

Discord:  [Discord-BOT-Tutorial Server](https://discord.gg/cGhEZuk)