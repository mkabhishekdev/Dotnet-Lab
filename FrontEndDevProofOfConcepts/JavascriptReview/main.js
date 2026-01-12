const person = {
    firstName: 'Abhishek',
    lastName: 'MK',
    age: 34,
    hobbies:['music','movies','sports'],
    address:{
        street: 'bangalore',
        city: 'bangalore',
        state: 'karnataka'
    }
}
console.log(person.hobbies[1]);

const todos = [
    {
        id: 1,
        text: 'take out trash',
        isCompleted: true
    },
    {
        id: 2,
        text: 'meeting with boss',
        isCompleted: true
    },
    {
        id: 3,
        text: 'dentist appointment',
        isCompleted: true
    }
];
console.log(todos);
console.log(todos[1]);

const todoJSON = JSON.stringify(todos);
console.log(todoJSON);

// for loop

for(let i = 0; i < 3; i++)
{
    console.log(i);
}

 