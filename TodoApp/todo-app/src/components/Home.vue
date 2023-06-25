<template>
    <div class="container">
        <div class="header">
            <p>My Todos</p>
            <a href="#" @click="handleClick"><i class="fa-solid fa-plus highlight"></i></a>
        </div>
        <div class="todos">
           
            <div v-for="todo in todos" class="todo">
                <div class="todoInfo">
                    <div class="info">
                        <p>{{ todo.Todo.Description }}</p>
                    </div>
                    <div class="controls">
                        <div class="complete"></div>
                        <a href="#"><i class="fa-solid fa-trash highlight"></i></a>
                        <a href="#"><i class="fa-solid fa-plus highlight"></i></a>
                    </div>
                </div>
                <div class="tasks" v-if="todo.Tasks.length != 0">
                    <div class="task" v-for="task in todo.Tasks">
                        <p>{{ task.TaskName }}</p>
                        <p>{{ task.Status }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <ul>
            <li v-for="todo in todos">{{ todo.Tasks }}</li>
        </ul>
    </div>
</template>
<script>
    import { ref } from 'vue'

    export default {
        name: 'Home',
        setup() {
            

            const todos = ref([])
            

            getTodo(1, (data) => {
                console.log(data);
                $.each(data, (i, v) => {
                    todos.value.push(v);
                });
            });


            //const p = ref(name)

            const handleClick = () => {
                //name.value = name.value == "Yasteel" ? "" : "Yasteel"
                alert("awe");
            }

            return { todos, handleClick };
        },
        data() {
            return {
                hello: "Data from vue"
            }
        }
    }
</script>

<style scoped>
    * {
        font-family: Helvetica, sans-serif;
    }

    body {
    }

    .highlight {
        color: #6BE91B;
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

    .todos {
        background: #3A3A3A;
        color: white;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    .todoInfo {
        background: #4E4C4C;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem;
    }

    .todoInfo a {
        margin-left: 1.5rem;
    }
</style>