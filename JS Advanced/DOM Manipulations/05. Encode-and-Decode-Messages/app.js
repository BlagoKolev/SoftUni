function encodeAndDecodeMessages() {
    let encryptBtn = document.getElementsByTagName('button')[0];
    let decryptBtn = document.getElementsByTagName('button')[1];
    encryptBtn.addEventListener('click', encryptAndSend);
    decryptBtn.addEventListener('click', decryptAndRead);

    function encryptAndSend(e) {

        let textArea = document.getElementsByTagName('textarea')[0];
        let message = textArea.value;
        let encodedMsg = '';
        console.log(message)
        Array.from(message).forEach(char => {
            encodedMsg += String.fromCharCode(char.charCodeAt(0) + 1);
        })
        textArea.value = '';
        document.getElementsByTagName('textarea')[1].value = encodedMsg;
    }
    function decryptAndRead(e) {
        let msgForDecrypt = document.getElementsByTagName('textarea')[1].value;
        let decryptedMsg = '';

        Array.from(msgForDecrypt).forEach(char => {
            decryptedMsg += String.fromCharCode(char.charCodeAt(0) - 1);
        })

        document.getElementsByTagName('textarea')[1].value = decryptedMsg;
    }

} 
