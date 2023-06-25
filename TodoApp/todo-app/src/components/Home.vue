<template>
    <div class="container">
        <div class="header">
            <p>My Todos</p>
            <a href="#" @click="handleClick"><i class="fa-solid fa-plus highlight"></i></a>
        </div>
        <div class="todos">
            <div class="todo">
                <div class="info">
                    <p>Description</p>
                </div>
                <div class="controls">
                    <div class="complete"></div>
                    <a href="#"><i class="fa-solid fa-trash highlight"></i></a>
                    <a href="#"><i class="fa-solid fa-plus highlight"></i></a>
                </div>
            </div>
            <div class="todo">
                <div class="info">
                    <p>Description</p>
                </div>
                <div class="controls">
                    <div class="complete"></div>
                    <a href="#"><i class="fa-solid fa-trash highlight"></i></a>
                    <a href="#"><i class="fa-solid fa-plus highlight"></i></a>
                </div>
            </div>
            <div class="todo">
                <div class="info">
                    <p>Description</p>
                </div>
                <div class="controls">
                    <div class="complete"></div>
                    <a href="#"><i class="fa-solid fa-trash highlight"></i></a>
                    <a href="#"><i class="fa-solid fa-plus highlight"></i></a>
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
            const name = ref("Yasteel")
            const surname = ref("Gungapursat")

            //const p = ref(name)

            const handleClick = () => {
                //name.value = name.value == "Yasteel" ? "" : "Yasteel" 
                alert("awe");
            }

            return { name, surname, handleClick };
        },
        data() {
            return {
                hello: "Data from vue"
            }
        }
    }
</script>

<style scoped>
    *{
        font-family: Helvetica, sans-serif;
    }

    body{
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

    p{
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

    .todo {
        background: #4E4C4C;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem;
    }

    .todo a{
        margin-left: 1.5rem;
    }

    
</style>