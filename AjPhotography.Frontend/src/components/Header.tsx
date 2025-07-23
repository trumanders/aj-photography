import { Link } from 'react-router-dom';
import './Header.css';

function Header() {
  return (
    <>    
      <div className="header">
        <Link to="/">
          <img className="header-logo" src="/logo-gray.jpg" alt="Logo" />
        </Link>
        <Link to="/photos">FOTOGRAFIER</Link>
        <Link to="/about">OM MIG</Link>
        <Link to="/contact">KONTAKT</Link>
      </div>
    </>
  );
}

export default Header;