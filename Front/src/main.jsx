import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App'
import { BrowserRouter } from 'react-router-dom'
import Nav from './components/nav/nav'
import { Provider } from 'react-redux'
import {store} from './redux/store/store'

ReactDOM.createRoot(document.getElementById('root')).render(
	<Provider store={store}>
	<BrowserRouter>
		<React.StrictMode>
			<Nav/>
			<App />
		</React.StrictMode>
	</BrowserRouter>
	</Provider>
)
