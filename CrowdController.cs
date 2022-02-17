using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public bool m_isDemocrat = false;  
    public bool m_isRepublican = false;

    public IndividualController[] m_individuals;

    public void MoveCrowd(bool republican, bool democrat)
    {
        switch (m_isDemocrat)
        {
            case true:
                switch (democrat && !republican)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            individual.Move();
                        }
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }

        switch (m_isRepublican)
        {
            case true:
                switch (republican && !democrat)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            individual.Move();
                        }
                        break;
                    case false: break;
                }
                break;
            case false: break;
        }
    }

    public void CheckWinLose() {
        switch (CodeManager.Instance.GameManager_.m_isRepublican)
        {
            case true:
                switch (m_isRepublican)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            switch (individual.m_isRepublican)
                            {
                                case true:
                                    individual.m_self.SetTrigger("Win");
                                    break;
                                case false:
                                    individual.m_self.SetTrigger("Lose");
                                    break;
                            }
                        }
                        break;
                    case false:
                        break;
                }

                switch (m_isDemocrat)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            switch (individual.m_isRepublican)
                            {
                                case true:
                                    individual.m_self.SetTrigger("Win");
                                    break;
                                case false:
                                    individual.m_self.SetTrigger("Lose");
                                    break;
                            }
                        }
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                switch (m_isRepublican)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            switch (individual.m_isRepublican)
                            {
                                case true:
                                    individual.m_self.SetTrigger("Lose");
                                    break;
                                case false:
                                    individual.m_self.SetTrigger("Win");
                                    break;
                            }
                        }
                        break;
                    case false:
                        break;
                }

                switch (m_isDemocrat)
                {
                    case true:
                        foreach (IndividualController individual in m_individuals)
                        {
                            switch (!individual.m_isRepublican)
                            {
                                case true:
                                    individual.m_self.SetTrigger("Win");
                                    break;
                                case false:
                                    individual.m_self.SetTrigger("Lose");
                                    break;
                            }
                        }
                        break;
                    case false:
                        break;
                }
                break;
        }
    }
}
