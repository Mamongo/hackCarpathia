let modal = document.querySelector(".modal")
let overlay = document.querySelector(".overlay")
let sidebar = document.querySelector(".sidebar")
let tasks = document.querySelector("#tasks")

async function fetchTasks(){
    let request = await fetch("http://localhost:5288/gettask",{
        method:"POST"
    })
    let data = await request.json()
    data.map(task=>{
        let taskToAdd = document.createElement("div")
        taskToAdd.innerHTML = `
        <div class="task" onclick="showInfo(false,'block','${task.id}')">
            <img src="./public/assets/corporate_fare_FILL0_wght400_GRAD0_opsz24.svg" width="40" alt="#">
            <h4>${task.title}</h4>
            <img src="./public/assets/award_star_FILL0_wght400_GRAD0_opsz34.svg" width="40" alt="">
        </div>`
        
        tasks.appendChild(taskToAdd)
    })
    localStorage.setItem("tasks",JSON.stringify(data))
}
fetchTasks()

function showInfo(handleModal,bool,id=null){
    if(id!=null){
        let task = JSON.parse(localStorage.getItem("tasks")).find(task=>task.id==id)
        document.querySelector("#company-name").textContent = task.companyname;
        document.querySelector("#task-name").textContent = task.title;
        document.querySelector(".task-description").textContent = task.description;
        document.querySelector(".task-prize").textContent = task.price;

    }
    bool=="block" ? modal.style.display = "flex" : modal.style.display = "none";
    overlay.style.display = bool;
}
function navActive(elem){
    let elements = [...sidebar.children]
    elements.map(elem=>{
        if(![...elem.classList].includes("logo")){
            elem.classList.remove("active")
        }
    })
    elem.parentNode.parentNode.classList.add("active")
    console.log(elem, elem.parentNode)
}