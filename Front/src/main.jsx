import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import App from './App'
import { BrowserRouter } from 'react-router-dom'
import Nav from './components/nav/Nav'
import Footer from './components/footer/Footer'


ReactDOM.createRoot(document.getElementById('root')).render(
	<BrowserRouter>
		<React.StrictMode>
			<Nav />
			<App />
			<Footer />
		</React.StrictMode>
	</BrowserRouter>
)
