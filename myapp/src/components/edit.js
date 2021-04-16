import React, { Component } from "react";
import axios from "axios";

export default class edit extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      age: "",
    };
  }

  componentDidMount(){
       const id = this.props.match.params.id;
       axios
        .get(`https://localhost:44341/api/employee/${id}`)
        .then((res) => {
          console.log(res.data.name);


          this.setState({
            name: res.data.name,
           age: res.data.age,
          });
        
          // if (res.data.success) {
          //   console.log(res.data.docs);
          //   this.setState({
          //     name: res.data.name,
          //     age: res.data.docs.age,
          //   });

          //   console.log(this.state.name)
          //   console.log(this.state.docs);
          // }
          // console.log(this.state.name)
        });
  }

  onSubmit = (e) => {
      const id = this.props.match.params.id;
    e.preventDefault();
    const {name , age} = this.state;
    const data = {
      name: name,
      age: age,
    };
    console.log(data);
    axios.put(`https://localhost:44341/api/employee/${id}`, data).then((res) => {
      
        alert("Edit Successful");
        this.setState({
          name: "",
          age: "",
          
        });
        console.log(this.state.docs);
    
    });
  };



  handleInput = (e) => {
    const { name, value } = e.target;
    this.setState({
      ...this.state,
      [name]: value,
    });
  };

  render() {
    return (
      <div className="container">
        <form>
          <div className="form-group">
            <label htmlFor="exampleFormControlInput1">Employee Name</label>
            <input
              value={this.state.name}
              onChange={this.handleInput}
              name="name"
              type="text"
              className="form-control"
              id="exampleFormControlInput1"
              placeholder="Enter Employee "
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
