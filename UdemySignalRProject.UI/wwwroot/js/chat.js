var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7224/SignalRHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {

    var currintTime = new Date();
    var currentHour = currintTime.getHours();
    var currentMinute = currintTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");

    span.style.fontWeight = "bold";
    span.textContent = user;

    li.appendChild(span);
    li.innerHTML += `:${message} -${currentHour}:${currentMinute}`

    document.getElementById("messageList").appendChild(li);

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;


}).catch((err) => {
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