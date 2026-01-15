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

for(let i = 0; i < todos.length; i++)
{
    console.log(todos[i].text);
}

// forEach, map, filter
todos.forEach(function(todo){
    console.log(todo.text);
})


const todoText = todos.map(function(todo){
                    return todo.text;
                });
console.log(todoText);

const todoFilter = todos.filter(function(todo){
                      return todo.isCompleted == true;
}).map(function(todo){
    return todo.text;
})
console.log(todoFilter);


const todoJSON = JSON.stringify(todos);
console.log(todoJSON);

// for loop
for(let i = 0; i < 3; i++)
{
    console.log(`For loop number: ${i}`);
}

// while
let i = 0;
while( i < 10)
{
    console.log(`while loop: ${i}`);
    i++;
} 

const x = 4;
const y = 10;

if(x === 10)
{
    console.log('x is 10');
}
else
{
    console.log('x is not 10');
}

const z = 12;
const color = z > 10 ? 'blue':'yellow';
console.log(color);

switch(color)
{
    case 'red':
        console.log("hey its red color");
        break;
    case 'blue':
        console.log("Jai Bhim, its blue");
        break;
    default:
        console.log('color is not red or blue');
        break;
}

//functions

function addNums(num1, num2)
{
    console.log(num1+num2);
}

addNums(11,9);



