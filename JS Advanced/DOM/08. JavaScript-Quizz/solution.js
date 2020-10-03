function solve() {
  let event = document.getElementById('quizzie');
  event.addEventListener('click', onClick);
  const sections = document.getElementsByTagName('section');
  let correctAnswers = 0;
  let questionNumber = 0;

  function onClick(e) {

    if (e.target.className === 'answer-text') {
      let answer = e.target.textContent;
      if (answer === 'onclick'
        || answer === 'JSON.stringify()'
        || answer === 'A programming API for HTML and XML documents') {
        correctAnswers++;
      }
      sections[questionNumber].style.display  = 'none';
      questionNumber++
     
      if (sections[questionNumber] !== undefined) {
        sections[questionNumber].style.display  = 'block';
      
      } else {
        let result = document.querySelector('#results > li > h1');
        document.querySelector('#quizzie > ul').style.display = 'block'

        if (correctAnswers === 3) {
          result.textContent = 'You are recognized as top JavaScript fan!'
        } else {
          result.textContent = `You have ${correctAnswers} right answers`
        }
      }

    }
  }

}

