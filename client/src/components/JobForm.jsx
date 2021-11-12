import React, { useState } from 'react'
import jobsService from '../helpers/jobsService'
import swal from 'sweetalert';


const JobForm = ({ createJob }) => {
    const [job, setJob] = useState({
        name: '',
        salary: 0,
    })

    const { name, salary } = job

    const updateState = e => {
        setJob({
            ...job,
            [e.target.name]: e.target.value 
        })
    }

    const handleSubmit = (e) => {
      e.preventDefault()

      if (name.trim() === '' || salary === 0) return
      
      jobsService.create({
        name: job.name,
        salary: Number(job.salary)
      })
      .then(job => { 
          swal("Trabajo ingresado", "success")
          createJob(job)
        })

      setJob({
        name: '',
        salary: 0
      })
    }
    return (
        <form className="form" onSubmit={handleSubmit}>
            <div className="row">
                <div className="col my-3">
                    <input
                        name="name"
                        className="form-control"
                        onChange={updateState}
                        value={name}
                        placeholder="Ingrese nombre del trabajo" 
                        autoFocus
                    />
                </div>
                <div className="col my-3">
                    <input
                        name="salary"
                        className="form-control"
                        type="number"
                        onChange={updateState}
                        value={salary}
                        placeholder="Ingrese salario del trabajo" 
                        autoFocus
                    /> 
                </div>
            </div>
            <button className="btn btn-primary" type="submit">Agregar trabajo</button>
        </form>
    )
}

export default JobForm
