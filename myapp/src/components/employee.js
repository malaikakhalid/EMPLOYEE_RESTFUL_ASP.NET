import React, { Component } from "react";
import axios from "axios";

export default class Books extends Component {
  constructor(props) {
    super(props);
    this.state = {
      docs: [],
    };

    
    
  }

  

  componentDidMount() {
    this.getEmployee();
    console.log("running")
  }
  getEmployee() {
    axios.get("https://localhost:44341/api/employee").then((res) => {
       
      console.log(res.data);
      this.setState({docs: res.data})
     
    });
  }
  
 
  

  onDelete = (id) => {
    console.log(id);
    console.log("hi")
    axios.delete(`https://localhost:44341/api/employee/${id}`).then((res) => {
      console.log(res.data);
      this.getEmployee();
    });
  };

  
  render() {
    return (
      <div>
        
        <div>
          <button type="button" className="btn ">
            <a href="/add">ADD NEW EMPLOYEE</a>
          </button>
        </div>

        {this.state.docs.map((doc, index) => (
          <div
            className="card"
            style={{
              width: "18rem",
              display: "inline-block",
              margin: "20px",
            }}
          >
            <div className="card-body">
              <h5 className="card-title">
                <a href={`/books/${doc.id}`}>{doc.name}</a>
              </h5>
              
              
              <p className="card-text">{doc.age}</p>
             
              <button type="button" className="btn btn-info">
                <a href={`/edit/${doc.id}`}>EDIT</a>
              </button>
              <button type="button" className="btn btn-danger">
                <a  onClick={() => this.onDelete(doc.id)}>
                  DELETE
                </a>
              </button>
             
            </div>
          </div>
        ))}
      </div>
    );
  }
}
