function solve() {
    let taskField = document.getElementById('task');
    let descriptionField = document.getElementById('description');
    let dateField = document.getElementById('date');
    let addButton = document.getElementById('add');
    addButton.addEventListener('click', addTask);
    let sections = Array.from(document.querySelectorAll('section'));

    function addTask(e) {
        e.preventDefault();
        let taskFieldValue = taskField.value;
        let descriptionFieldValue = descriptionField.value;
        let dateFieldValue = dateField.value;
    
        if (taskFieldValue !== ''
            && descriptionFieldValue !== ''
            && dateFieldValue !== '') {

            let newTask = document.createElement('article');

            let taskTitle = document.createElement('h3');
            taskTitle.textContent = taskFieldValue;
            newTask.appendChild(taskTitle);
 
            let taskDescription = document.createElement('p');
            taskDescription.textContent = 'Description: ' + descriptionFieldValue;
            newTask.appendChild((taskDescription));

            let taskDate = document.createElement('p');
            taskDate.textContent = 'Due Date: ' + dateFieldValue;
            newTask.appendChild((taskDate));

            let buttonContainer = document.createElement('div');
            buttonContainer.className = 'flex';
            let startBtn = document.createElement('button');
            let deleteBtn = document.createElement('button');
            startBtn.className = 'green';
            startBtn.textContent = 'Start';
            deleteBtn.className = 'red';
            deleteBtn.textContent = 'Delete';

            buttonContainer.appendChild(startBtn);
            buttonContainer.appendChild(deleteBtn);
            newTask.appendChild(buttonContainer);

            let newTaskContainer = sections[1].getElementsByTagName('div')[1];
            newTaskContainer.appendChild(newTask)

            taskField.value = '';
            descriptionField.value = '';
            dateField.value = '';

            newTask.addEventListener('click', onClick);
            let inProgress = document.getElementById('in-progress');
            function onClick(e) {
                e.preventDefault();
                if (e.target.textContent === 'Start') {

                    
                    //newTaskContainer.removeChild(e.currentTarget);

                    let delButton = e.currentTarget.getElementsByTagName('button')[0];
                    delButton.className = 'red';
                    delButton.textContent = 'Delete';

                    let finishBtn = e.currentTarget.getElementsByTagName('button')[1];
                    finishBtn.className = 'orange';
                    finishBtn.textContent = 'Finish';

                    e.currentTarget.addEventListener('click', lastAction)

                    inProgress.appendChild(e.currentTarget);

                } else if (e.target.textContent === 'Delete') {
                    newTaskContainer.removeChild(e.currentTarget);
                }
            }

            function lastAction(x){
                if (x.target.textContent==='Delete') {
                    inProgress.removeChild(x.currentTarget);
                }else if (x.target.textContent === 'Finish') {
                    let uselessContainer = x.currentTarget.getElementsByTagName('div')[0];
                    x.currentTarget.removeChild(uselessContainer);
                    let complete = sections[sections.length-1];
                    complete.getElementsByTagName('div')[1].appendChild(x.currentTarget);
                }

            }
        }
    }


}