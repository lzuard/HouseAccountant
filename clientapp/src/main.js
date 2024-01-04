import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import UiComponents from '@/components/UI'

import '@/assets/styles/colors-dark-theme.css'


const createdApp = createApp(App)

UiComponents.forEach(uiComponent => {
    console.log(`this is component name ${uiComponent.name}`)
    createdApp.component(uiComponent.name, uiComponent)
})
createdApp
    .use(router)
    .mount('#app')
