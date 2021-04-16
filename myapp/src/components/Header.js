import React, { Component } from 'react'

export default class Header extends Component {
    render() {
        return (
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="#">
              FETCHING RESTFUL API
            </a>
            
            <div className="collapse navbar-collapse" id="navbarNav">
              <ul className="navbar-nav">
                <li className="nav-item active">
                  <a className="nav-link" href="/">
                    List Employees <span className="sr-only"></span>
                  </a>
                </li>
                
              </ul>
            </div>
          </nav>
        );
    }
}
