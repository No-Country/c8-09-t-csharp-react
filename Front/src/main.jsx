import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App'
import { BrowserRouter } from 'react-router-dom'
import Nav from './components/nav/Nav'
<<<<<<< HEAD
import Footer from './components/footer/Footer'

=======
import { Provider } from 'react-redux'
import {store} from './redux/store/Store'
>>>>>>> c00a6a90b457dbb39894084bfc3e3e453a4796dd

ReactDOM.createRoot(document.getElementById('root')).render(
	<Provider store={store}>
	<BrowserRouter>
		<React.StrictMode>
			<Nav />
			<App />
			<Footer />
		</React.StrictMode>
	</BrowserRouter>
	</Provider>
)
