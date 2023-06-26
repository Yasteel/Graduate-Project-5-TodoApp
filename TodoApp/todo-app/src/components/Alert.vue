<template>
    <div class="alert_message">
        <p class="message"></p>
        <span><i class="message_type_icon fas"></i></span>
    </div>
</template>

<script>
    export default {
        name: "Alert",
        
        setup(props, context) {
            const showAlert = () => {
                console.log("awe")
            }

            context.expose({ showAlert })

            return {
                showAlert
            }
            
        }
    };
</script>

<style scoped>
    :root {
        --error: #a72a30;
        --blackish: #373F51;
        --grayish: #646b7a;
        --whiteish: #D8DBE2;
        --blueish: #1CB5E0;
    }

    .alert_message {
        font-size: 16px;
        font-family: helvetica;
    }

    .alert_message,
    .alert_message::before {
        background: var(--blackish);
    }

    .alert_message.success,
    .alert_message.success.alert_message::before {
        color: var(--blueish);
    }

    .alert_message.fail,
    .alert_message.fail.alert_message::before {
        background: var(--whiteish);
        color: var(--error);
    }
</style>