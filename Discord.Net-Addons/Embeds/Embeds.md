# Working with Embeds in Discord.Net

## 🤔 What is an Embed

You have probably seen them pop up on Discord from time to time, when you post a link the Discord client will also display an embed under that link. Sometimes they have just a Title and Description, sometimes they will have more in them as-well such as when you post a youtube link or a tweet link. 

*Put very simply, this is an Embed:*

![EmbedExample](https://drax.codes/images/u/Bl9PNq.png)

You can use Embeds themselves in many different ways. The main reason to use them though is normally to make your command output, from your bot, a little neater or just generally better looking. 

## 🛠 Creating an Embed

The best way to start learning how to create an embed is to head over to this link **[HERE](https://leovoel.github.io/embed-visualizer/)**. From that visualizer you can learn the different components available to you in an Embed. It also has a neat feature of being able to generate the code for you, but for the purpose of this guide, I will outline how to do it below.

### Basics

In the Discord.Net library, we have access to a class called EmbedBuilder. This is the class that allows us to construct an Embed using the builder pattern (Don't worry if you don't know what the builder pattern is, it becomes clear below).

```cs
//First start by instantiating yourself a new EmbedBuilder
var ourEmbed = new EmbedBuilder();
```

Once we have the builder we can start adding to it, this is where we can start using the Builder aspects of this class. If you start typing `embedBuilder.` as soon as you put the `.` you will notice a lot of properties and methods become available to you. The methods you want to focus on are those prepended with the word `With`, EG: `WithTitle()`.

These methods allow you to add to the embed and format as you see fit. For example, if I wanted an Embed with a title that said "*Hello World*" I would do the following.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World");
```

Now because the embedBuilder allows for method chaining, you can add everything you want to your embed all in one go. For example, if I wanted the same title but also with a Description and an Image, I would do the following.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png");
```

### Colour

As you may have noticed on the example image of an Embed at the top of this page, I have a custom colour for the bar at the left side of the embed. You can change this yourself by using the `WithColor()` method. So leading on from the snippet above.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red);
```

### Fields

An Embed also has another component to it called a Field. A field is simply a nice way of formatting a key/value type structure, with the key being a Title and the value being the Description.

Here as an image as an example of using some fields:

![EmbedFields](https://drax.codes/images/u/WKzY1T.png)

As you can see, in the example image above we have 4 fields, two of which are not inline, meaning they don't go next to each other, the other two being inline, so they are next to each other. To construct these fields we do the following (leading on again from the last snippet).

This time we make use of the method named `AddField()`.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true);
```

Note that the last two fields, we add above, have the extra optional `bool` parameter which we set to `true` this is simply a parameter that allows us to specify if the field should be inline or not. (Default, is false)

Also note that ***fields can not be empty*** for both the key and value. If you want to give the effect that the field title or description is blank, you can use a zero width character. (Common zero width character to use: `\u200b`)

### Author

Another component of an Embed is the Author. The method we use to add an Author to the Embed is named `WithAuthor()`. The only difference between the Author component and the others we have used before is that it takes an `Action<EmbedAuthorBuilder>`. TO see how to make use of that, look at the snippet below.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(author => {
        author.WithName("Author Name")
              .WithUrl("https://discordapp.com")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    });
```

Note that you can also make use of an overload the `.WithAuthor()` method has, this is simply a method that allows you to pass the parameters for `Name`, `Url` & `IconUrl` as strings.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(name: "Author Name", url: "https://discordapp.com", iconUrl: "https://cdn.discordapp.com/embed/avatars/0.png");
```

### Footer

The footer works much like the Author component above. This time we are going to make use of the `.WithFooter()` method.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(author => {
        author.WithName("Author Name")
              .WithUrl("https://discordapp.com")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    })
    .WithFooter(footer => {
        footer.WithText("footer text")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    });
```

You can also use a similar overload as the Author component above. This overload works the same as the `.WithAuthor()` method, where it allows you to pass the paramters as strings rather than the `Action`.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(name: "Author Name", url: "https://discordapp.com", iconUrl: "https://cdn.discordapp.com/embed/avatars/0.png");
    .WithFooter(text: "Some Footer Text", iconUrl: "https://cdn.discordapp.com/embed/avatars/0.png");
```

### Building the Embed

Now we have the embed built with everything we want to display in it, we can move onto actually telling the library to build it and give us an `Embed` rather than an `EmbedBuilder`.

The difference between an `Embed` & `EmbedBuilder` is that the `Embed` is what we send into Discord (Shown below), and the `EmbedBuilder` is what allows us to construct it.

To build the Embed, it's as simple as calling `.Build()`.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(author => {
        author.WithName("Author Name")
              .WithUrl("https://discordapp.com")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    })
    .WithFooter(footer => {
        footer.WithText("footer text")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    })
    .Build();
```

### Sending the Embed

Now we have the embed itself, we can send it into Discord just like you would any other message, except this time we are going to make use of the optional `embed` parameter on the `SendMessageAsync()` or `ReplyAsync()` method.

```cs
var ourEmbed = new EmbedBuilder()
    .WithTitle("Hello World")
    .WithDescription("This is my super awesome description.")
    .WithImageUrl("https://SomeImage.com/foo.png")
    .WithColour(Color.Red)
    .AddField("Field Title", "Some of these properties have certain limits...")
    .AddField("Field Title", "Namely they have a character limit.")
    .AddField("Field Title", "these last two", true)
    .AddField("Field Title", "are inline fields", true)
    .WithAuthor(author => {
        author.WithName("Author Name")
              .WithUrl("https://discordapp.com")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    })
    .WithFooter(footer => {
        footer.WithText("footer text")
              .WithIconUrl("https://cdn.discordapp.com/embed/avatars/0.png");
    })
    .Build();

await ReplyAsync(embed: ourEmbed);
//Or
await Context.Channel.SendMessageAsync(embed: ourEmbed);
```

### Conclusion

That's it. That's all there is to building and sending an embed. There are certainly more components of an embed you can use, however it's up to you to figure those out. If you have any further questions regarding this guide, join our server at the link below.

Author: Draxis#0359

Discord: [Programming With Peter](https://discord.gg/cGhEZuk)
