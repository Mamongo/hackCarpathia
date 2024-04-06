let modal = document.querySelector(".modal")
let overlay = document.querySelector(".overlay")
function showInfo(task,bool){
    bool=="block" ? modal.style.display = "flex" : modal.style.display = "none";
    overlay.style.display = bool;
}