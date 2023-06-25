<template>
    <div>
        <h1> {{ hello }} </h1>
    </div>
</template>

<script>
    export default {
        setup() {
            name: 'Home'
        },
        data() {
            return {
                hello: "Data from vue"
            }
        }
    }
</script>

<style scoped>
</style>