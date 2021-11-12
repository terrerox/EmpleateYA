import React from 'react'
import jobsService from '../helpers/jobsService'
import swal from 'sweetalert';


const UpdateJobForm = ({ setIsUpdating, setJobToUpdate, jobToUpdate, updateJob }) => {

    const { name, salary } = jobToUpdate

    const updateState = e => {
        setJobToUpdate({
            ...jobToUpdate,
            [e.target.name]: e.target.value 
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault()
  
        if (salary === 0) return
        
        jobsService.update({
          id: jobToUpdate.id,
          name: jobToUpdate.name,
          salary: Number(jobToUpdate.salary),
          status: Number(jobToUpdate.status)
        })
        .then(updatedJob => {
            swal("Trabajo actualizado")
            updateJob(updatedJob)
        })

        setIsUpdating(false)
    }

    return (
        <form className="form" onSubmit={handleSubmit}>
            <div className="row">
                <div className="col my-3">
                    <input
                        name="name"
                        readOnly
                        className="form-control"
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
            <div className="row">
                <div className="col my-3">
                    <input
                        name="status"
                        type="radio"
                        className="form-check-input"
                        onChange={updateState}
                        value='1'
                        autoFocus
                    />
                    <label className="form-check-label">
                        Vacante
                    </label>
                </div>
                <div className="col my-3">
                    <input
                        name="status"
                        className="form-check-input"
                        type="radio"
                        onChange={updateState}
                        value='2'
                        autoFocus
                    />
                    <label className="form-check-label">
                        Ocupado
                    </label>
                </div>
            </div>
            <button 
                className="btn btn-primary"
                type="submit"
            > 
                Actualizar trabajo
            </button>
        </form>
    )
}

export default UpdateJobForm
