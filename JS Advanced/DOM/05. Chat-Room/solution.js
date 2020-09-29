function solve() {
 const inputField = document.getElementById('chat_input');
 const sendButton = document.getElementById('send')
 .addEventListener('click', onClick);
 const boxMessage = document.getElementById('chat_messages');

 function onClick(){
   let message = inputField.value;
   let myBoxMessage = document.createElement('div');
   myBoxMessage.className = 'message my-message';
   myBoxMessage.textContent = message;
   boxMessage.appendChild(myBoxMessage);
   inputField.value = '';
 }
 
}


/* let button = document.getElementById("send").addEventListener("click", onClick)
const messageBoard = document.getElementById("chat_messages");

 function onClick(){
   let newMessage = document.getElementById("chat_input").value;
   let newMessageContainer = document.createElement("div");
   newMessageContainer.className = "message my-message";
   newMessageContainer.textContent = newMessage;
   messageBoard.appendChild(newMessageContainer);
   
 } */