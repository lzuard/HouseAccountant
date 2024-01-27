<template>
    <div class="element_container">
        <div class="container_header">
            <label
                v-text="headerText"></label>
            <main-button 
                @click="showContent" 
                v-text="buttonText"
                v-if="isHidable"></main-button>
        </div>
        <Transition name="slide">
            <div class="container_content" v-if="isShowContent" >
                <slot></slot>
            </div>
        </Transition>
    </div>
</template>

<script>
export default{
    name: "content-box",
    props:{
        isHidable: {
            type: Boolean,
            dafault: true,
            required: true
        },
        headerText: {
            type: String,
            default: "Empty header"
        },
        defaultIsShowContent:{
            type:Boolean,
            default: false
        }
    },
    data(){
        return{
            isShowContent: !this.isHidable || this.defaultIsShowContent,
            buttonText: this.defaultIsShowContent?"-":"+"
        }
    },
    methods:{
        showContent(){
            this.isShowContent = !this.isShowContent
            this.buttonText = this.isShowContent? "-":"+"
        }
    }
}

</script>

<style scoped>
    .element_container{
        margin: 20px;
        border-radius: 10px;
        background-color: var(--black-6);
        color: var(--black-1);
    }
    .container_header{
        padding:5px 20px 5px 20px;
        overflow: hidden;
        font-size: 30px;
        display: flex;
        border-radius: 10px;
        justify-content: space-between;
        
    }
    .container_content{
        border-top: 2px solid var(--blue-3);
        padding: 20px;
        overflow: hidden;
        transform-origin: top;
    }
    .slide-enter, .slide-leave-to{
        transform: scaleY(0);
    }
</style>