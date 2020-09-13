function solve(input) {

    const text = {};

    for (const sentence of input) {
        newSentence = escapePunctuation(sentence);
        console.log(newSentence+'!');
        let words = newSentence.split(' ').filter(x => x.trim());
        for (const word of words) {
            if (!text.hasOwnProperty(word)) {
                text[word] = 0;
            }
            text[word]++;
        }

    }
    console.log(JSON.stringify(text))

    function escapePunctuation(text) {
        let newText = text.replace(/[^A-Za-z0-9_]/g, " ");
        console.log(newText +'!')
       return newText.replace(/\s{2,}/, ' ')
      
    }
}

solve(["Far too slow, you're far too slow."])