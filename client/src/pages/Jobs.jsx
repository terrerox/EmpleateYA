import React, { useState, useEffect } from 'react'
import jobsService from '../helpers/jobsService'
import JobForm from '../components/JobForm'
import JobsTable from '../components/JobsTable'
import UpdateJobForm from '../components/UpdateJobForm'

const Jobs = () => {

    const [jobs, setJobs] = useState([])
    const [isUpdating, setIsUpdating] = useState(false)
    const [jobToUpdate, setJobToUpdate] = useState({})

    useEffect(() => {
        jobsService.getAll()
            .then(jobs => {
                setJobs(jobs)
            })
    }, [])

    const createJob = job => {
        setJobs([ ...jobs, job ]);
    }

    const updateJob = updatedJob => {
        const allJobs = jobs.filter( job => job.id !== updatedJob.id)
        setJobs([ ...allJobs, updatedJob ]);
    }
    
    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6">
                    { isUpdating 
                        ?<UpdateJobForm 
                            setIsUpdating={setIsUpdating}
                            setJobToUpdate={setJobToUpdate}
                            updateJob={updateJob}
                            jobToUpdate={jobToUpdate}
                         />

                        : <JobForm 
                            createJob={createJob}
                          />
                    }
                </div>
                <div className="col-md-6">
                    <JobsTable
                        jobs={jobs}
                        setIsUpdating={setIsUpdating}
                        setJobToUpdate={setJobToUpdate}
                    /> 
                </div>
            </div>
        </div>
    )
}

export default Jobs
