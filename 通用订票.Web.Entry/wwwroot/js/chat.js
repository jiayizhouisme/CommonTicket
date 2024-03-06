"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/chathub", {
    accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJiYmI1MWQxNy1lMjZiLTRlMWUtYWIyNS0yNjczYjM5ZGYzZmMiLCJuYW1lIjoiYWRtaW4iLCJ0ZW5hbnQtaWQiOiJzaGFnb3UyIiwicGVybWlzc2lvbnMiOjEsImlhdCI6MTcwOTY5NjQ3MywibmJmIjoxNzA5Njk2NDczLCJleHAiOjE3MTAxMjg0NzMsImlzcyI6Inpob3VqaWF5aSIsImF1ZCI6InN1bm55c2t5In0.XLo10l0d1yCBptKhUrg1gYYWDbvCCvNaEyzSghHieto",
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