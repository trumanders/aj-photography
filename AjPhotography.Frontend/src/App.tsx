// import { BrowserRouter, Routes, Route, Link } from 'react-router-dom'
import { BrowserRouter} from 'react-router-dom'

import Home from './pages/Home'
import Header from './components/Header'
import './App.css'

function App() {

  return (
    <BrowserRouter>
      <Header />
      <Home />
    </BrowserRouter>
  )
}

export default App
