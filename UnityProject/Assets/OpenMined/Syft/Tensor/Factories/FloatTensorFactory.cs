﻿using System.Collections.Generic;
using UnityEngine;

namespace OpenMined.Syft.Tensor.Factories
{
    
    public class FloatTensorFactory
    {
        private Dictionary<int, FloatTensor> tensors;
        private ComputeShader shader;

        public FloatTensorFactory(ComputeShader _shader)
        {
            shader = _shader;
            tensors = new Dictionary<int, FloatTensor>();
        }
        
        public FloatTensor Get(int id)
        {
            return tensors[id];
        }

        public int Count()
        {
            return tensors.Count;
        }
        
        public void Delete(int id)
        {
            Debug.LogFormat("<color=purple>Removing Tensor {0}</color>", id);
			
            var tensor = tensors [id];
            tensors.Remove (id);
			
        }

        public FloatTensor Create(int[] _shape,
            float[] _data = null,
            ComputeBuffer _dataBuffer = null,
            ComputeBuffer _shapeBuffer = null,
            ComputeShader _shader = null,
            bool _copyData = true,
            bool _dataOnGpu = false,
            bool _autograd = false,
            bool _keepgrads = false,
            string _creation_op = null)
        {
            
            FloatTensor tensor = new FloatTensor();
            
            tensor.init(this,
                _shape,
                _data,
                _dataBuffer,
                _shapeBuffer,
                _shader,
                _copyData,
                _dataOnGpu,
                _autograd, 
                _keepgrads,
                _creation_op);
            
            tensors.Add(tensor.Id,tensor);

            return tensor;
        }
       
        public ComputeShader GetShader()
        {
            return shader;
        }
    }
}