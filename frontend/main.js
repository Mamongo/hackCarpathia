let modal = document.querySelector(".modal")
let overlay = document.querySelector(".overlay")
let sidebar = document.querySelector(".sidebar")
function showInfo(task,bool){
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