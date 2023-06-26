<template>
    <div class="container">
        <div class="header">
            <div class="inputs">
                <input type="text" id="name" placeholder="Name" />
                <input type="text" id="description" placeholder="Description" />
            </div>
            <button @click="addTodo" class="addTodoBtn">Add Todo <span><i class="fa-solid fa-plus highlight"></i></span></button>
            <button @click="updateTodo" class="updateTodoBtn">Save</button>
        </div>
           
        <div class="todoContainer">
            <div v-for="todo in todos" class="todo">
                <div class="tasks" v-if="todo.Tasks.length != 0">

                    <div class="task" v-for="task in todo.Tasks">
                        <div class="taskInfo">
                            <div class="info">
                                <p class="taskName">{{ task.TaskName }}</p>
                                <p class="taskDescription">{{ task.Description }}</p>
                            </div>

                            <div class="controls">

                                <button :data-taskid="task.TaskId" @click="completeTodo" class="status" v-if="task.Status.toLowerCase() != 'complete'">Complete</button>
                                <button class="status" v-else disabled>Complete <span><i class="fa-solid fa-check highlight"></i></span></button>

                                <button :data-taskid="task.TaskId" @click="editTodo"><i class="fa-solid fa-pen highlight"></i></button>
                                <button :data-taskid="task.TaskId" @click="deleteTodo"><i class="fa-solid fa-trash highlight"></i></button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
    <Alert></Alert>
</template>
<script>
    import { ref } from 'vue'
    import Alert from '../components/Alert.vue'
    export default {
        name: 'Home',
        components: {
            Alert
        },
        setup() {
            

            const todos = ref([])
            

            getTodo(1, (data) => {
                console.log(data);
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
                        if (res.status = 200) {
                            clearFields();

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

                updateTask(taskId, "", "", "complete", (res) => {
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

            const editTodo = (e) => {
                var taskId = $(e.target).closest("button").attr("data-taskid");
                var name = $(e.target).closest(".task").find(".taskName").text();
                var description = $(e.target).closest(".task").find(".taskDescription").text();

                $("input#name").val(name);
                $("input#description").val(description);

                $(".addTodoBtn").css({ "display": "none" });
                $(".updateTodoBtn").css({ "display": "block" }).attr("data-taskId", taskId);
            };

            const updateTodo = (e) => {
                var name = $("input#name").val();
                var description = $("input#description").val();
                var taskId = $(e.target).attr("data-taskId");

                console.log(taskId);

                updateTask(taskId, name, description, "modified", (res) => {
                    if (res.status == 200) {

                        $(".addTodoBtn").css({ "display": "block" });
                        $(".updateTodoBtn").css({ "display": "none" });


                        clearFields();
                        getTodo(1, (data) => {
                            todos.value = [];
                            $.each(data, (i, v) => {
                                todos.value.push(v);
                            });
                        });
                    }
                })
            }

            const clearFields = () => {
                $("input#name").val("");
                $("input#description").val("");
            }

            return {
                todos,
                addTodo,
                deleteTodo,
                completeTodo,
                editTodo,
                updateTodo
            };
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

    .todoContainer{
        max-height: 70vh;
        overflow-y: auto;
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

    .updateTodoBtn{
        display: none;
    }

    .inputs input:last-child {
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

    @media only screen and (max-width: 994px) {        
        .header {
            flex-direction: column;
            justify-content: space-between;
            align-items: flex-start;
            gap: 1rem;
            margin-bottom: 1rem;
        }
        .inputs{
            display: flex;
            flex-wrap: wrap;
            gap: 1rem;
        }

        .inputs input{

            justify-self: stretch;
        }
    }


</style>