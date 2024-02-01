"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/chathub", {
    accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI4MGZiM2E3MC1hMjE0LTZmZGQtZjFmMy0xYTM2MDk4NGRhNjgiLCJuYW1lIjoiYWRtaW4iLCJ0ZW5hbnQtaWQiOiIiLCJwZXJtaXNzaW9ucyI6MSwiaWF0IjoxNzA2ODA3NzY4LCJuYmYiOjE3MDY4MDc3NjgsImV4cCI6MTcwNzIzOTc2OCwiaXNzIjoiemhvdWppYXlpIiwiYXVkIjoic3Vubnlza3kifQ.xO3JHJP1Sg-fuIVvXIAasKgXucnYG6Z1ANfEv-qDj0M",
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