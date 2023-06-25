function test() {
    console.log("Test - call from vue setup");
}

// ============================= TODOs =============================

// GET
function getTodo(userId, test) {
    axios
        .get(`https://localhost:7137/api/Todo/${userId}`)
        .then(res => test(res.data))
        .catch(err => console.error(err));
}

// POST
function createTodo(userId, description) {
    let data = JSON.stringify({
        UserId: userId,
        Description: description
    });

    console.log(data);
    axios
        .post(`https://localhost:7137/api/Todo/${userId}`, data, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(res => console.log(res))
        .catch(err => console.error(err));
}

// PUT
function updateTodo(todoId, description) {
    axios
        .patch(`https://localhost:7137/api/Todo/${todoId}`, {
            Description: description
        })
        .then(res => console.log(res))
        .catch(err => console.error(err));
}

// DELETE
function deleteTodo(todoId) {
    axios
        .delete(`https://localhost:7137/api/Todo/${todoId}`)
        .then(res => console.log(res))
        .catch(err => console.error(err));
}

// ============================= TASKs =============================

// GET
function getTask(userId) {

}

// POST
function createTask() {

}

// PUT
function updateTask() {

}

// DELETE
function deleteTask() {

}