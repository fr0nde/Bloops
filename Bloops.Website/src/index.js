//import '../node_modules/bootstrap/dist/css/bootstrap.css'
import './styles/style.scss'

const navItems = document.getElementById('nav-items')

document.getElementById('nav-button').addEventListener('click', e => {
  e.currentTarget.classList.toggle('nav-icon-toggled')
  navItems.classList.toggle('nav-items-opened')
})
