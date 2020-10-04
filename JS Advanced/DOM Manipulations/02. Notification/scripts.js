function notify(message) {
    let messageContainer = document.getElementById('notification');
    messageContainer.textContent = message;
    messageContainer.style.display = 'block';
    setTimeout(function(){
        messageContainer.style.display = 'none';},2000);
}