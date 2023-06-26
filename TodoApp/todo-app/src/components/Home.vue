<template>
    <div class="container">
        <div class="header">
            <div class="inputs">
                <input type="text" id="name" placeholder="Name" />
                <input type="text" id="description" placeholder="Description" />
            </div>
            <button @click="addTodo">Add Todo <span><i class="fa-solid fa-plus highlight"></i></span></button>

        </div>
           
        <div v-for="todo in todos" class="todo">
            <div class="tasks" v-if="todo.Tasks.length != 0">
                    
                <div class="task" v-for="task in todo.Tasks">
                    <div class="taskInfo">
                        <div class="info">
                            <p>{{ task.TaskName }}</p>
                            <p>{{ task.Description }}</p>
                            <p>{{ task.TaskId }}</p>
                        </div>
                            
                        <div class="controls">

                            <button :data-taskid="task.TaskId" @click="completeTodo" class="status" v-if="task.Status.toLowerCase() == 'new'">Complete</button>
                            <button class="status" v-else disabled>Complete <span><i class="fa-solid fa-check highlight"></i></span></button>

                            <button><i class="fa-solid fa-pen highlight"></i></button>
                            <button :data-taskid="task.TaskId" @click="deleteTodo"><i class="fa-solid fa-trash highlight"></i></button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</template>
<script>
    import { ref } from 'vue'

    export default {
        name: 'Home',
        setup() {
            

            const todos = ref([])
            

            getTodo(1, (data) => {
                todos.value = [];
                $.each(data, (i, v) => {
                    todos.value.push(v);
                });
            });


            //const p = ref(name)

            const addTodo = () => {
                var name = $("input#name").val();
                var description = $("input#description").val();

                if (name.length < 1 || description.length < 1) {
                    alert("Fields cannot be left Empty");
                }
                else {
                    createTask(name, description, (res) => {
                        console.log(res);

                        if (res.status = 200) {
                            getTodo(1, (data) => {
                                todos.value = [];
                                $.each(data, (i, v) => {
                                    todos.value.push(v);
                                });
                            });
                        }
                    });
                }
            }

            const deleteTodo = (e) => {
                var taskId = $(e.target).closest("button").attr("data-taskid");
                deleteTask(taskId, (res) => {
                    console.log(res);

                    if (res.status == 200) {
                        getTodo(1, (data) => {
                            todos.value = [];
                            $.each(data, (i, v) => {
                                todos.value.push(v);
                            });
                        });
                    }
                });
            };

            const completeTodo = (e) => {
                var taskId = $(e.target).closest("button").attr("data-taskid");

                updateTask(taskId, "", "complete", (res) => {
                    if (res.status == 200) {
                        getTodo(1, (data) => {
                            todos.value = [];
                            $.each(data, (i, v) => {
                                todos.value.push(v);
                            });
                        });
                    }
                });


            };

            return { todos, addTodo, deleteTodo, completeTodo };
        },
        data() {
            return {
                hello: "Data from vue"
            }
        }
    }
</script>

<style >
    * {
        font-family: Helvetica, sans-serif;
    }

    body {
        background: #242424;
    }

    .header {
        background: #3A3A3A;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem;
        color: white;
        margin-bottom: 1rem;
    }

    p {
        padding: 0;
        margin: 0;
    }

    input, button{
        background: none;
        color: white;
        border: none;
        outline: none;
        padding: .5rem 1rem;
        margin-right: 1rem;
        box-shadow: 0 0 1px 0 white;
        border-radius: 5px;
        transition: box-shadow 300ms ease-in-out;
    }

    .inputs input:last-child{
        width: 400px;
    }

    .inputs input:is(:hover, :focus), button:is(:hover, :focus) {
        box-shadow: 0 0 5px 0 #2EF536;
    }

    button:is(:hover, :focus), button:is(:hover, :focus) i{
        color: #2EF536;
    }

    button span{
        margin-left: 1rem;
    }

    /*tasks*/
    .tasks {
        background: #3A3A3A;
        display: flex;
        justify-content: space-between;
        padding: 1rem;
        flex-direction: column;
        gap: 2rem;
        border-bottom: 1px solid #242424;
        color: white;
    }

    .taskInfo{
        display: flex;
        justify-content: space-between;
        align-items: center;

    }

    .taskInfo p:first-child{
        color: #2EF536;
    }

    .taskInfo .controls{
        display: flex;
        gap: 1.5rem;
    }

    .taskDescription{
        padding: 0 2rem;
    }

    a{
        padding: .7rem;
    }

    a:is(:hover,:focus){
        box-shadow: 0 0 5px 0px #ffffff52;
    }

    a:is(:hover, :focus) i{
        color: #6BE91B;
    }

</style>