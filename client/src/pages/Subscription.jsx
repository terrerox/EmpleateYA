import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
import jobsService from '../helpers/jobsService'
import candidatesService from '../helpers/candidatesService'
import CandidateInfo from '../components/CandidateInfo'
import HiringJobsTable from '../components/HiringJobsTable'

const Subscription = () => {

    const [hiringJobs, setHiringJobs] = useState([])
    const [selectedCandidate, setSelectedCandidate] = useState({})

    const { id } = useParams();

    useEffect(() => {
        candidatesService.getById(id)
            .then(candidate => setSelectedCandidate(candidate))
    
        jobsService.getAll()
            .then(jobs => {
                const onlyHiringJobs = jobs.filter(job => job.status === 1)
                setHiringJobs(onlyHiringJobs)
            })
    }, [])

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6">
                    <CandidateInfo
                        selectedCandidate={selectedCandidate}
                    />
                </div>
                <div className="col-md-6">
                    <HiringJobsTable
                        hiringJobs={hiringJobs}
                        selectedCandidate={selectedCandidate}
                    /> 
                </div>
            </div>
        </div>
    )
}

export default Subscription
