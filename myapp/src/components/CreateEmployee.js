import React, { Component } from "react";
import axios from "axios";

export default class CreatBook extends Component {
  constructor(props) {
    super(props)
    this.state = {
      name:"",
      age:"",
     
    };
  }



  onSubmit = (e) => {
      e.preventDefault();
     const { name , age } = this.state;
     const data = {
         name: name,
         age: age,
         
     };
     console.log(data);

     axios.post("https://localhost:44341/api/employee", data).then((res) => {
      
         alert("data added");
         this.setState({
           name: "",
           age: "",
           
         });
         console.log(this.state.docs);
      
     });

  }

  handleInput = (e) => {
const {name , value} = e.target;
this.setState({
    ...this.state,
    [name]:value

})


  };
  
  render() {
    return (
      <div className="container">
        <form>
          <div className="form-group">
            <label htmlFor="exampleFormControlInput1"> Name</label>
            <input
              value={this.state.name}
              onChange={this.handleInput}
              name="name"
              type="text"
              className="form-control"
              id="exampleFormControlInput1"
              placeholder="Enter Employee Name"
            />
          </div>

          <div className="form-group">
            <label htmlFor="exampleFormControlInput1">Employee Age</label>
            <input
              value={this.state.age}
              onChange={this.handleInput}
              name="age"
              type="text"
              className="form-control"
              id="exampleFormControlInput1"
              placeholder="Enter Employee Age"
            />
          </div>

          
          <button
            type="submit"
            className="btn btn-primary mb-2"
            onClick={this.onSubmit}
          >
            Submit
          </button>
        </form>
      </div>
    );
  }
}
