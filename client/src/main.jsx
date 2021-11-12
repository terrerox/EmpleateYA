import React from 'react'
import ReactDOM from 'react-dom'
import { 
  BrowserRouter,
  Routes,
  Route 
} from "react-router-dom";
import './index.css'
import Home from './pages/Home'
import Jobs from './pages/Jobs'
import Candidates from './pages/Candidates'
import Subscription from './pages/Subscription'

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />}>
          <Route path="jobs" element={<Jobs />} />
          <Route path="candidates" element={<Candidates />} />
          <Route path="subscription/:id" element={<Subscription />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
)
