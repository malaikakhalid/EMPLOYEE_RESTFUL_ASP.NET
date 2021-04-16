import React, { Component } from "react";
import axios from "axios";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  BrowserRouter,
} from "react-router-dom";

import Books from "./components/employee";
import CreateBook from "./components/CreateEmployee";
import edit from "./components/edit";
import Header from "./components/Header";

export default class App extends Component {
  render() {
    return (

      <BrowserRouter>
        <div>
          <Header />
          <Route path="/" exact component={Books} />
          
          <Route path="/add" component={CreateBook} />
          <Route path="/edit/:id" component={edit} />
        </div>
      </BrowserRouter>
    
    );
  }
}
