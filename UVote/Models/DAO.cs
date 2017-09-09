using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Configuration;
using System.IO;

namespace UVote.Models
{
    public class DAO
    {
        SqlConnection connection;
        public string message = string.Empty;

        // Initialize the connection object
        public void Connection()
        {
            connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionStringLocal"].ConnectionString);
        }

        #region Student
        public int Insert(StudentModel model)
        {
            int count = 0;
            SqlCommand cmd;
            string password;
            Connection();
            cmd = new SqlCommand("uspInsertStudent", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentNumber", model.StudentNumber);
            cmd.Parameters.AddWithValue("@firstName", model.FirstName);
            cmd.Parameters.AddWithValue("@lastName", model.LastName);
            cmd.Parameters.AddWithValue("@telephone", model.Telephone);
            cmd.Parameters.AddWithValue("@email", model.Email);
            cmd.Parameters.AddWithValue("@addressLine1", model.AddressLine1);
            cmd.Parameters.AddWithValue("@addressLine2", model.AddressLine2);
            cmd.Parameters.AddWithValue("@addressLine3", model.AddressLine3);
            cmd.Parameters.AddWithValue("@addressLine4", model.AddressLine4);
            cmd.Parameters.AddWithValue("@employeeId", model.EmployeeId);
            password = Crypto.HashPassword(model.Password);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
        #endregion

        #region Admin
        // Create an admin
        public int InsertAdmin(AdminModel adminModel)
        {
            int count = 0;
            SqlCommand cmd;
            string password;
            Connection();
            cmd = new SqlCommand("uspInsertAdmin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeId", adminModel.EmployeeId);
            cmd.Parameters.AddWithValue("@name", adminModel.Name);
            cmd.Parameters.AddWithValue("@email", adminModel.Email);
            password = Crypto.HashPassword(adminModel.Password);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return count;
        }

        // Login an admin
        public string AdminLogin(AdminModel adminModel)
        {
            string employeeId = null;
            string name = null;
            string password;
            SqlCommand cmd;
            SqlDataReader reader;
            Connection();
            cmd = new SqlCommand("uspAdminLogin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", adminModel.Email);

            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    password = reader["Password"].ToString();
                    if (Crypto.VerifyHashedPassword(password, adminModel.Password))
                    {
                        employeeId = reader["EmployeeId"].ToString();
                        name = reader["Name"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return employeeId;
        }

        #endregion

        #region Campaign
        // Create a campaign
        public int InsertCampaign(CampaignModel campaignModel)
        {
            int count = 0;
            SqlCommand cmd;
            Connection();
            cmd = new SqlCommand("uspInsertCampaign", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@roleTitle", campaignModel.RoleTitle);
            cmd.Parameters.AddWithValue("@roleDetails", campaignModel.RoleDetails);
            cmd.Parameters.AddWithValue("@officeTerm", campaignModel.OfficeTerm);
            cmd.Parameters.AddWithValue("@campaignStart", campaignModel.CampaignStart);
            cmd.Parameters.AddWithValue("@campaignEnd", campaignModel.CampaignEnd);
            cmd.Parameters.AddWithValue("@employeeId", campaignModel.EmployeeId);

            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
        #endregion

        #region Candidate
        public int InsertCandidate(CandidateModel candidateModel)
        {
            int count = 0;
            SqlCommand cmd;
            Connection();
            cmd = new SqlCommand("uspInsertCandidate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@candidateId", candidateModel.CandidateId);
            cmd.Parameters.AddWithValue("@firstName", candidateModel.FirstName);
            cmd.Parameters.AddWithValue("@lastName", candidateModel.LastName);
            cmd.Parameters.AddWithValue("@manifesto", candidateModel.Manifesto);
            cmd.Parameters.AddWithValue("@imageUrl", candidateModel.ImageUrl);
            cmd.Parameters.AddWithValue("@previousHistory", candidateModel.PreviousHistory);
            cmd.Parameters.AddWithValue("@campaignId", candidateModel.CampaignId);
            cmd.Parameters.AddWithValue("@employeeId", candidateModel.EmployeeId);

            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return count;
        }
        #endregion
    }
}