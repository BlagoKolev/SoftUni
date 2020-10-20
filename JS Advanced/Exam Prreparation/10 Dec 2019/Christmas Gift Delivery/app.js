function solution() {

    let sections = Array.from(document.querySelectorAll('section'));
    let addGiftSection = sections[0];
    let listOfGifts = sections[1];
    let sentGifts = sections[2];
    let discardedGifts = sections[3];
    let unorderedLists = Array.from(document.querySelectorAll('section > ul'));
    let inputField = document.querySelector('div > input');
    //закачаме eventlistener директно на контейнера
    addGiftSection.addEventListener('click', addGift);
    let sortedGifts = [];
    function addGift(a) {




        if (a.target.textContent === 'Add gift') {

            let giftToAdd = inputField.value;
            // създаваме новите елементи
            if (giftToAdd.length === 0) {
                return;
            }
            let newGiftContainer = document.createElement('li');
            newGiftContainer.className = 'gift';



            let sendBtn = document.createElement('button');
            sendBtn.id = 'sendButton';
            sendBtn.textContent = 'Send';

            let discardBtn = document.createElement('button');
            discardBtn.id = 'discardButton';
            discardBtn.textContent = 'Discard';


            //закачаме новите елементи в SendGift контейнера
           // newGiftContainer.insertAdjacentText("afterbegin", giftToAdd)
           newGiftContainer.appendChild(document.createTextNode(giftToAdd));
            newGiftContainer.appendChild(sendBtn);
            newGiftContainer.appendChild(discardBtn);

            sortedGifts.push(newGiftContainer);
            sortedGifts.sort((a, b) => a.textContent.localeCompare(b.textContent));
            unorderedLists[0].innerHTML = '';
            sortedGifts.forEach(gift => unorderedLists[0].appendChild(gift));

            //изчистваме инпут полето
            inputField.value = '';

            //закачаме eventlistener на двата нови бутона send / discard
            console.log(sortedGifts.length)

            sendBtn.addEventListener('click', sendGift);
            discardBtn.addEventListener('click', discardGift);

            function sendGift(b) {
              
               sortedGifts = sortedGifts.filter(l => l.firstChild.textContent !== newGiftContainer.firstChild.textContent);
                let giftContainerToSend = b.target.parentElement;
                giftContainerToSend.removeChild(sendBtn);
                giftContainerToSend.removeChild(discardBtn);
                unorderedLists[1].appendChild(giftContainerToSend);
                console.log(sortedGifts.length)

            }

            function discardGift(c) {
               
                sortedGifts = sortedGifts.filter(l => l.firstChild.textContent !== newGiftContainer.firstChild.textContent);
                let giftContainerToDiscard = c.target.parentElement;
                giftContainerToDiscard.removeChild(sendBtn);
                giftContainerToDiscard.removeChild(discardBtn);
                unorderedLists[2].appendChild(giftContainerToDiscard);
                console.log(sortedGifts.length)

            }
            
        }
    }
}