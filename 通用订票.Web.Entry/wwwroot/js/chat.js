"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/chathub", {
    accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI4MGZiM2E3MC1hMjE0LTZmZGQtZjFmMy0xYTM2MDk4NGRhNjgiLCJuYW1lIjoiYWRtaW4iLCJ0ZW5hbnQtaWQiOiIiLCJpYXQiOjE3MDU3NDQxMDksIm5iZiI6MTcwNTc0NDEwOSwiZXhwIjoxNzA2MTc2MTA5LCJpc3MiOiJ6aG91amlheWkiLCJhdWQiOiJzdW5ueXNreSJ9.CHUuP0NhkDxV1URHyY5VeVif5uPgVZvew2lLLuy7n4w"
}
    ).build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});