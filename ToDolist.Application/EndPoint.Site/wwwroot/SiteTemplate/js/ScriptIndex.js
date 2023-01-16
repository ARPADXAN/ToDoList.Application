const todos = document.querySelectorAll(".todo");
const all_status = document.querySelectorAll(".status");
let draggableTodo = null;

todos.forEach((todo) => {
    todo.addEventListener("dragstart", dragStart);
    todo.addEventListener("dragend", dragEnd);
});

function dragStart(event) {
    draggableTodo = this;
    setTimeout(() => {
        this.style.display = "none";
    }, 0);
    console.log("dragStart");
}

function  dragEnd(event) {
    elementId = $(event.target).attr('data-id');
    divId = $(event.target).parent().attr('id');
    console.log(elementId);
    console.log(divId)
    //send id to server
   
    $.post(`/change-state-item/${elementId}/${divId}`, function (data) {
       console.log(data)
    });

    draggableTodo = null;
    setTimeout(() => {
        this.style.display = "block";
    }, 0);
    console.log("dragEnd");


    $(document).ready(function () {
        function handleclick(event, no_status) {
            console.log('event', event);
            console.log('status', no_status);
        }
        document.querySelectorAll(".status").forEach(status => {
            const id = status.getAttribute('data-Id');
            status.addEventListener('click', (e) => handleclick(e, id));
        })
    });

    $(document).ready(function () {
        function handleclick(event,status_notstarts) {
            console.log('event', event);
            console.log('status', status_notstart);
        }
        document.querySelectorAll(".status").forEach(status => {
            const id = status.getAttribute('data-Id');
            status.addEventListener('click', (e) => handleclick(e, id));
        })
    });
   
}

all_status.forEach((status) => {
    status.addEventListener("dragover", dragOver);
    status.addEventListener("dragenter", dragEnter);
    status.addEventListener("dragleave", dragLeave);
    status.addEventListener("drop", dragDrop);
});

function dragOver(e) {
    e.preventDefault();
    //   console.log("dragOver");
}

function dragEnter() {
    this.style.border = "3px dashed #ccc";
    console.log("dragEnter");
}

function dragLeave() {
    this.style.border = "none";
    console.log("dragLeave");
}

var div1 = [];
var div2 = [];
var div3 = [];
var div4 = [];
var all33 = {};
function dragDrop(e) {
    console.log(e.target.id);
    this.style.border = "none";
    this.appendChild(draggableTodo);
    //div1 = [];
    //div2 = [];
    //div3 = [];
    //div4 = [];
    //for (i = 0; i < all_status.length; i++) {

    //    if (all_status[i] == document.getElementsByClassName("todo-container")[0].children[0]) {
    //        for (j = 0; j < all_status[i].getElementsByClassName("todo").length; j++) {
    //            div1.push(all_status[i].getElementsByClassName("todo")[j].childNodes[0].nodeValue)

    //        }

    //    }
    //    if (all_status[i] == document.getElementsByClassName("todo-container")[0].children[1]) {
    //        for (j = 0; j < all_status[i].getElementsByClassName("todo").length; j++) {
    //            div2.push(all_status[i].getElementsByClassName("todo")[j].childNodes[0].nodeValue)
    //        }
    //    }
    //    if (all_status[i] == document.getElementsByClassName("todo-container")[0].children[2]) {
    //        for (j = 0; j < all_status[i].getElementsByClassName("todo").length; j++) {
    //            div3.push(all_status[i].getElementsByClassName("todo")[j].childNodes[0].nodeValue)
    //        }
    //    }
    //    if (all_status[i] == document.getElementsByClassName("todo-container")[0].children[3]) {
    //        for (j = 0; j < all_status[i].getElementsByClassName("todo").length; j++) {
    //            div4.push(all_status[i].getElementsByClassName("todo")[j].childNodes[0].nodeValue)

    //        }
    //    }

    //    all33 = { d1: div1, d2: div2, d3: div3, d4: div4 };
   
    //}
    //console.log(all33)
  
  
   
}

//

/* modal */
const btns = document.querySelectorAll("[data-target-modal]");
const close_modals = document.querySelectorAll(".close-modal");
const overlay = document.getElementById("overlay");

btns.forEach((btn) => {
    btn.addEventListener("click", () => {
        document.querySelector(btn.dataset.targetModal).classList.add("active");
        overlay.classList.add("active");
    });
});

close_modals.forEach((btn) => {
    btn.addEventListener("click", () => {
        const modal = btn.closest(".modal");
        modal.classList.remove("active");
        overlay.classList.remove("active");
    });
});

window.onclick = (event) => {
    if (event.target == overlay) {
        const modals = document.querySelectorAll(".modal");
        modals.forEach((modal) => modal.classList.remove("active"));
        overlay.classList.remove("active");
    }
};

/* اضافه کردن کارت *//* getElementById*/
const todo_submit = document.getElementById("todo_submit");

todo_submit.addEventListener("click", createtodo);

 function createtodo() {
     const todo_div = document.createElement("div");
  
     const input_val = document.getElementById("todo_input").value;
     const txt = document.createTextNode(input_val);
     const decortion = document.getElementById("todo_input_1").value;

     var e = document.getElementById("myselect");
     var value = e.value;
     let selector = e.options[e.selectedIndex].text;


    
     console.log(selector);//in aslan ejra nemeshe ke bekhad color bedeاره چون که ویئو بگ نمیشناس

     if (selector == "معمولی") {
         todo_div.style.backgroundcolor = "#4caf50";
     }
     if (selector == "فوری") {
         todo_div.style.backgroundcolor = "#f39c12";
     }
     if (selector == "اضطراری") {
         todo_div.style.backgroundcolor = "#e6177e";
     }
     todo_div.appendChild(txt);
     todo_div.classList.add("todo");
     todo_div.setAttribute("draggable", "true");

     todo_div.title = decortion;
     /* create span */
     const span = document.createElement("span");
     const span_txt = document.createTextNode("\u00d7");
     span.classList.add("close");
     span.appendChild(span_txt);

     todo_div.appendChild(span);
     
     no_status.appendChild(todo_div);
     $(todo_div).hide();
     $(todo_div).attr('data-insert', '0');
     span.addEventListener("click", () => {
         span.parentelement.style.display = "none";
     });
     //   console.log(todo_div);
 /*    todo_form*/
     todo_div.addEventListener("dragstart", dragstart);
     todo_div.addEventListener("dragend", dragend);
     
     document.getElementById("todo_input").value = "";
     document.getelementbyid("todo_input_1").value = "";
     document.getelementbyid("nofication_time_1").value = "";
     document.getelementbyid("nofication_time_2").value = "";
     document.getelementbyid("mycheck").checked = false;

     todo_form.classList.remove("active");
     overlay.classList.remove("active");
 }

const close_btns = document.querySelectorAll(".closetodo");

close_btns.foreach((btn) => {
    btn.addeventlistener("click", () => {
        btn.parentelement.style.display = "none";
    });
});

function myFunction() {
    // Get the checkbox
    var checkBox = document.getElementById("myCheck");
    // Get the output text
    var text1 = document.getElementById("nofication_time_1");
    var text2 = document.getElementById("nofication_time_2");
    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        text1.style.display = "block";
        text2.style.display = "block";
    } else {
        text1.style.display = "none";
        text2.style.display = "none";
    }
};

